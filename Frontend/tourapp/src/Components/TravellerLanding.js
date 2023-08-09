import React, { useEffect, useState } from "react";
import { Carousel } from 'react-responsive-carousel';

import PackageForm from "./PackageForm";
import { Link } from "react-router-dom";
import TravellerPackages from "./TravellerPackages";
function TravellerLanding(){
    var logOut=()=>{localStorage.clear()};
    const[packages,setpackages]=useState([]);
    const[agent,setagent]=useState([]);
    const filteredPackages = packages.filter(packages => packages.agencyId === agent.agencyID);


    useEffect(()=>{
        getpackages();
     
      },[]);

     

      const getpackages = () => {
        fetch("http://localhost:5038/api/Packages", {
      method: 'GET',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
        //'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      
        })
      .then(async (response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const myData = await response.json();
        console.log(myData);
        setpackages(myData);
        console.log(packages);
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
      }
      const [images, setImages] = useState([]);
  useEffect(() => {
    const fetchImages = async () => {
      try {
        const response = await fetch("http://localhost:5033/api/TourImage/GettingImages");
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const data = await response.json();
        // Assuming data is an array of image objects with imagePath property
        const imageUrls = data.map(image => image.imagePath);
        setImages(imageUrls);
      } catch (error) {
        console.error("Error fetching images:", error);
      }
    };
  
    fetchImages();
  }, []);

      return(
        <div>
            <div>
    <Carousel showArrows={true} showThumbs={false}>
{images.map((image, index) => (
  <div key={index}>
    <img src={image} alt={`Tour ${index}`} />
  </div>
))}
</Carousel>
</div>
       
        <div className="Packs">
                <b>Packages:</b>
              </div>
              
              <div className="GetAll" >
                {
                    filteredPackages.map((packages,index)=>{
                    return(<TravellerPackages key={index} user = {packages}/>)
                })
                }
            </div>
           
                
             </div>
              
      )

}

export default TravellerLanding;
import React, { useState } from "react";
import { ToastContainer, toast } from 'react-toastify';
import './PackageForm.css';


function PackageForm(){

    var [packages,setPackages]=useState({
        
            "packageName": "string",
            "travelAgencyName": "string",
            "description": "string",
            "duration": "string",
            "startDate": "string",
            "endDate": "string",
            "price": 0,
            "destination": "string",
            "transportation": "string",
            "availabilityCount": 0
        
    });

    const [itenary, setitenary] = useState({
        
            "packageId": 0,
           
            "dayAndDayTitle": "",
            "destinationName": "",
            "destinationDescription": ""
          
    });

    const [images, setImages] = useState({
      "name":"string",
      "image":"file"

});
    const AddImages = (event) => {
      event.preventDefault();
    
      // Prepare the images for upload (e.g., convert to FormData)
      const formData = new FormData();
      images.forEach((image, index) => {
        formData.append(`image-${index}`, image);
      });
    
      fetch("http://localhost:5038/api/UploadImages", {
        method: "POST",
        body: formData,
      })
        .then(async (response) => {
          if (response.status === 200) {
            console.log(response.status);
            const data = await response.json();
            console.log(data);
            toast.success("Images Added! :)", {
              position: toast.POSITION.TOP_CENTER,
            });
          } else {
            toast.error("Images Not added", {
              position: toast.POSITION.TOP_CENTER,
            });
          }
        })
        .catch((error) => {
          console.log(error);
        });
    };
    

    const AddPackage = (event) => {
        event.preventDefault(); // Prevent form submission
    
        console.log(packages);
    
        fetch("http://localhost:5038/api/Packages", {
          method: "POST",
          headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
          },
          body: JSON.stringify(packages)
        })
          .then(async (response) => {
            if (response.status === 200) {
              console.log(response.status);
              const data = await response.json();
              console.log(data);
              localStorage.setItem("packId",data.packageId);
              toast.success("Added! :)", {
                position: toast.POSITION.TOP_CENTER
              });
              
            } else {
              toast.error("Not added", {
                position: toast.POSITION.TOP_CENTER
              });
            }
          })
          .catch((error) => {
            console.log(error);
          });
      };

      const AddItenary = (event) => {
        event.preventDefault(); // Prevent form submission
        console.log(localStorage.getItem("packId"));
        const packId = localStorage.getItem("packId");
        itenary.packageId = parseInt(packId);
        console.log(itenary.packageId);
    
        fetch("http://localhost:5038/api/Itinerary", {
          method: "POST",
          headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
          },
          body: JSON.stringify(itenary)
        })
          .then(async (response) => {
            if (response.status === 200) {
              console.log(response.status);
              const data = await response.json();
              console.log(data);
              toast.success("Added! :)", {
                position: toast.POSITION.TOP_CENTER
              });
              
            } else {
              toast.error("Not added", {
                position: toast.POSITION.TOP_CENTER
              });
            }
          })
          .catch((error) => {
            console.log(error);
          });
      };



    
      
    return(
        <div className="content">
            <ToastContainer/>
              <br/>
              <div className="container py-5">
        <div className="row justify-content-center align-items-center h-100">
          <div className="col-12 col-lg-9 col-xl-7">
            <div className="card shadow-2-strong card-registration">
              <div className="card-body p-4 p-md-5">
                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Add package Form</h3>
                <form onSubmit={AddPackage}>
                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Name" className="form-control form-control-md" placeholder="Package Name" onChange={(event) => {
                          setPackages({ ...packages,packageName: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Speciality" className="form-control form-control-md" placeholder="Agency name" onChange={(event) => {
                          setPackages({ ...packages,travelAgencyName: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>
                  
                     <br/>
                    
                    
                  
                    
                  <div className="row">
                    <div className="col-md-6 mb-2">
                        From
                      <div className="form-outline">
                        <input type="text" id="DateOfBirth" className="form-control form-control-md" placeholder="FromDate" onChange={(event) => {
                          setPackages({ ...packages,startDate: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        To
                        <input type="text" id="DateOfBirth" className="form-control form-control-md" placeholder="ToDate" onChange={(event) => {
                          setPackages({ ...packages,endDate: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Email" className="form-control form-control-md" placeholder="Duration" onChange={(event) => {
                          setPackages({ ...packages,duration: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Phone" className="form-control form-control-md" placeholder="Destination" onChange={(event) => {
                          setPackages({ ...packages,destination: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  <div className="row">
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Address" className="form-control form-control-md" placeholder="transportation" onChange={(event) => {
                          setPackages({ ...packages,transportation: event.target.value })
                        }} />
                      </div>
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="number" id="Experience" className="form-control form-control-md" placeholder="price" onChange={(event) => {
                          setPackages({ ...packages,price: event.target.value })
                        }} />
                      </div>
                    </div>
                  </div>

                  
                      <div className="form-outline">
                        <input type="number" id="Password" className="form-control form-control-md" placeholder="available seats" onChange={(event) => {
                          setPackages({ ...packages,availabilityCount: event.target.value })
                        }} />
                      </div>
                   
                    <br/>
                  
                      <div className="form-outline">
                      <textarea
                      id="Description"
                      className="form-control form-control-md"
                      placeholder="Description"
                      rows="6" 
                      // Adjust the number of rows as needed
                      onChange={(event) => {
                        setPackages({ ...packages,description: event.target.value })
                      }} ></textarea>                      </div>
                    <br/>

                  <div>
                    <input className="btn btn-primary btn-md" type="submit" value="Add" />
                  </div>

                </form>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="container py-5">
        <div className="row justify-content-center align-items-center h-100">
          <div className="col-12 col-lg-9 col-xl-7">
            <div className="card shadow-2-strong card-registration">
              <div className="card-body p-4 p-md-5">
                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Itinerary</h3>
                <form onSubmit={AddItenary}>
                  <div className="row">
                    
                      <div className="form-outline">
                        <input type="text" id="DateOfBirth" className="form-control form-control-md" placeholder="Day and title" onChange={(event) => {
                          setitenary({ ...itenary,dayAndDayTitle: event.target.value })
                        }} />
                      </div>
                    
                  </div>
                  <br/>
                  <div className="row">
                    
                    
                  <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Email" className="form-control form-control-md" placeholder="Destination name"  onChange={(event) => {
                          setitenary({ ...itenary,destinationName: event.target.value })
                        }} />
                     </div>
                     
                    </div>
                    <div className="col-md-6 mb-2">
                      <div className="form-outline">
                        <input type="text" id="Email" className="form-control form-control-md" placeholder="Destination description" onChange={(event) => {
                          setitenary({ ...itenary,destinationDescription: event.target.value })
                        }} />
                     </div>
                     
                    </div>
                  </div>

                  <br/>
                  <div>
                    <input className="btn btn-primary btn-md" type="submit" value="Add" />
                  </div>

                </form>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="container py-5">
        <div className="row justify-content-center align-items-center h-100">
          <div className="col-12 col-lg-9 col-xl-7">
            <div className="card shadow-2-strong card-registration">
              <div className="card-body p-4 p-md-5">
                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Images</h3>
                <form>
                  <div className="row">
                    
                      <div className="form-outline">
                        <input type="text" id="DateOfBirth" className="form-control form-control-md" placeholder="Name" onChange={(event) => {
                          setImages({ ...packages,name: event.target.value })   }} />
                     
                  </div>
                  </div>
                  <br/>

                  <div className="row">
                                      
                <div className="form-outline">
                  <input type="file" id="UploadFile" className="form-control form-control-md" onChange={(event) => {
                    setImages([...event.target.files]);
                  }}/>
                </div>
              
                  </div>

                  <br/>
                  <div>
                    <input className="btn btn-primary btn-md" type="submit" value="Add" />
                  </div>

                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
              </div>
    )
}
export default PackageForm;
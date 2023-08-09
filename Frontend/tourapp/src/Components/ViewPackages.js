import React, { useEffect, useState } from "react";
import IndividualPacks from "./IndividualPacks";
import PackageForm from "./PackageForm";
import { Link } from "react-router-dom";
function Agentpackages(){
    var logOut=()=>{localStorage.clear()};
    const[packages,setpackages]=useState([]);
    const[agent,setagent]=useState([]);
    const filteredPackages = packages.filter(packages => packages.agencyId === agent.agencyID);


    useEffect(()=>{
        getpackages();
        getAgent();
      },[]);

      const getAgent = async (doctorId) => {
        const Agentemail = encodeURIComponent(localStorage.getItem("emailId")); // Encode the email
        const url = `http://localhost:5210/api/User/GetAgent?email=${Agentemail}`;
        fetch(url, {
          method: "GET",
          headers: {
            accept: "text/plain",
            "Content-Type": "application/json",
            //Authorization: "Bearer " + localStorage.getItem("token"),
          },
        })
        .then(async (response) => {
          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }
          const myData = await response.json();
          console.log(myData);
          setagent(myData);
          localStorage.setItem("agency status", myData.isApproved);
          localStorage.setItem("agent name",myData.name);
          localStorage.setItem("agencyName",myData.agencyName);
          localStorage.setItem("agentId",myData.travelAgentId);
          console.log(agent);
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
      }

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

      return(
        <div>
        <div className="status">
            <b>Name:{localStorage.getItem("agent name")}</b><br/>
            <b>Status:{localStorage.getItem("agency status")}</b>

        </div>
        <div className="Packs">
                <b>Packages:</b>
              </div>
              
              <div className="GetAll" >
                {
                    filteredPackages.map((packages,index)=>{
                    return(<IndividualPacks key={index} user = {packages}/>)
                })
                }
            </div>
            <div className="floating-button">
                <Link to="/addPack" className="btn btn primary">+
                </Link>
                
              </div></div>
              
      )

}

export default Agentpackages;
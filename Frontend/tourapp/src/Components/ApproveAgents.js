import React, { useEffect, useState } from "react";
import "./ApproveAgents.css";
import { Link, useNavigate } from "react-router-dom";
import AdminMenu from "./AdminMenu";

function ApproveAgents(props) {
  const [agent, setAgent] = useState([props.user]);
  const [showPopup, setShowPopup] = useState(false);

  useEffect(() => {
    if (agent[0]) {
      localStorage.setItem("agentId", agent[0].email);
      console.log("email");
      console.log(agent[0].email);
    }
  }, [agent]);




  const UpdateStatus = (agentEmail, isApproved) => {
    console.log("email" + localStorage.getItem("agentId"));
    const newStatus = isApproved === "Yes" ? "No" : "Yes";
       console.log(agentEmail);
       console.log(newStatus);
        fetch("http://localhost:5210/api/User/UpdateAgentStatus", {
          method: "PUT",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json"
            //Authorization: "Bearer " + localStorage.getItem("token")
          },
          body: JSON.stringify({travelAgentEmail:agentEmail,status:newStatus })
        })
          .then(async (response) => {
            if (response.status === 200) {
              const data = await response.json();
              setAgent([data]); // Update the doc state with the new data
            }
          })
          .catch((err) => {
            console.log(err);
          });
      };


  return (
    <div>
        <div className="card card-body IndividualDoctor card text-white bg-primary mb-3 shadow p-3 mb-5 rounded">
        <h5 className="card-title">{agent[0].name}</h5>
        <br />
        <p className="card-text">
          <b>Email - </b>
          {agent[0].email}
        </p>
        <p className="card-text">
          <b>DOB - </b>
          {agent[0].dateOfBirth}
        </p>
        
        <p className="card-text">
          <b>Agency - </b>
          {agent[0].agencyName}
        </p>
        <p className="card-text">
          <b>Phone - </b>
          {agent[0].phone}
        </p>
        <p className="card-text">
          <b>City - </b>
          {agent[0].address}
        </p>
        <p className="card-text">
          <b>Approved - </b>
          {agent[0].isApproved}
        </p>
        
        <button
          onClick={() => UpdateStatus(localStorage.getItem("agentId"), agent[0].isApproved)}
          
          className="card-link btn btn-secondary"
        >
        
          Change Status
        </button>
        
      </div>
        </div>
  );
}

export default ApproveAgents;

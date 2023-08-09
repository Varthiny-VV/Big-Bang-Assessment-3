import React, { useState, useEffect } from "react";
import { ToastContainer, toast } from 'react-toastify';
import './AgentRegister.css';
import {Link} from "react-router-dom";

function AgentRegister(){
  var [agent, setAgent] = useState({
       
            
    name: "",
    dateOfBirth: new Date(),
    phone: "",
    email: "",
    address: "",
    agencyName: "",
    gstNumber: "",
    passwordClear: ""    
});
const [registrationStatus, setRegistrationStatus] = useState(null);
useEffect(() => {
  if (registrationStatus === "registering") {
    // Make the API call here
    fetch("http://localhost:5210/api/User/RegisterTravelAgent", {
      method: "POST",
      headers: {
        accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(agent),
    })
      .then(async (response) => {
        if (response.ok) {
          setRegistrationStatus("success");
          console.log(response);
        } else {
          throw new Error("Error registering agent");
        }
      })
      .catch((error) => {
        console.log(error);
        setRegistrationStatus("error");
      });
  }
}, [registrationStatus, agent]);

const handleFormSubmit = (event) => {
  event.preventDefault();
  setRegistrationStatus("registering");
};

useEffect(() => {
  if (registrationStatus === 'success') {
    toast.success('Registration successful!', {
      position: toast.POSITION.TOP_RIGHT,
    });
  } else if (registrationStatus === 'error') {
    toast.error('Error registering agent', {
      position: toast.POSITION.TOP_RIGHT,
    });
  }
}, [registrationStatus]);

    return(
     
            <div className='agent_register_body'>
              <ToastContainer/>
            <body>
    <div class="agent_container">
      <header className='registration_header'>Registration Form</header>
      <div action="#" class="agent_register_form">
        <div class="input-box">
         
          <input type="text" placeholder="Enter full name" onChange={(event) => {
                  setAgent({ ...agent, "name": event.target.value });
                }}required />
        </div>
        <div class="input-box">
          
          <input type="text" placeholder="Enter agency name"onChange={(event) => {
                  setAgent({ ...agent, "agencyName": event.target.value });
                }} required />
        </div>
        <div class="input-box">
          
          <input type="text" placeholder="Enter email address"onChange={(event) => {
                  setAgent({ ...agent, "email": event.target.value });
                }} required />
        </div>
        <div class="column">
          <div class="input-box">
           
            <input type="number" placeholder="Enter phone number"onChange={(event) => {
                  setAgent({ ...agent, "phone": event.target.value });
                }} required />
          </div>
          <div class="input-box">
            
            <input type="date" placeholder="Enter birth date"onChange={(event) => {
                  setAgent({ ...agent, "dateOfBirth": event.target.value });
                }} required />
          </div>
        </div>
        
        <div class="input-box address">
          
          <input type="text" placeholder="Enter your address" onChange={(event) => {
                  setAgent({ ...agent, "address": event.target.value });
                }}required />
          
        </div>
        <div class="input-box GSTNumber">
      
          <input type="text" placeholder="Enter GST Number"onChange={(event) => {
                  setAgent({ ...agent, "gstNumber": event.target.value });
                }} required />
          
        </div>

        <div class="input-box password">
      
      <input type="text" placeholder="Enter new password"onChange={(event) => {
              setAgent({ ...agent, "passwordClear": event.target.value });
            }} required />
      
    </div>
        <button onClick={handleFormSubmit}>Submit</button>
        <ToastContainer />
        <div className="account_login"><br/>
        <p>
            Already have an account?{" "}
            <Link to="/login">Login here</Link>
          </p>
        </div>
      </div>
    </div>
  </body>
        </div>
        
    );
}

export default AgentRegister;
import React, { useState, useEffect } from "react";
import { ToastContainer, toast } from 'react-toastify';
import './TravellerRegister.css';
import {Link} from "react-router-dom";

function TravellerRegister(){
  var [traveller, setTraveller] = useState({
       
            
    name: "",
    gender: "",
    dateOfBirth: new Date(),
    phone: "",
    email: "",
    address: "",
    passwordClear: ""    
});
const [registrationStatus, setRegistrationStatus] = useState(null);
useEffect(() => {
  if (registrationStatus === "registering") {
    // Make the API call here
    fetch("http://localhost:5210/api/User/RegisterTraveller", {
      method: "POST",
      headers: {
        accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(traveller),
    })
      .then(async (response) => {
        if (response.ok) {
          setRegistrationStatus("success");
          console.log(response);
        } else {
          throw new Error("Error registering traveller");
        }
      })
      .catch((error) => {
        console.log(error);
        setRegistrationStatus("error");
      });
  }
}, [registrationStatus, traveller]);

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
    toast.error('Error registering traveller', {
      position: toast.POSITION.TOP_RIGHT,
    });
  }
}, [registrationStatus]);

    return(
        <div className='traveller_register_body'>
            <body>
    <div class="traveller_container">
      <header className='registration_header'>Registration Form</header>
      <div action="#" class="traveller_register_form">
        <div class="input-box">
          
          <input type="text" placeholder="Enter full name"  onChange={(event) => {
                  setTraveller({ ...traveller, "name": event.target.value });
                }} required />
        </div>
        <div class="input-box">
       
          <input type="text" placeholder="Enter email address"  onChange={(event) => {
                  setTraveller({ ...traveller, "email": event.target.value });
                }}  required />
        </div>
        <div class="traveller_column">
          <div class="input-box">
           
            <input type="number" placeholder="Enter phone number"  onChange={(event) => {
                  setTraveller({ ...traveller, "phone": event.target.value });
                }} required />
          </div>
          <div class="input-box">
           
            <input type="date" placeholder="Enter birth date"  onChange={(event) => {
                  setTraveller({ ...traveller, "dateOfBirth": event.target.value });
                }}  required />
          </div>
        </div>
        
        <div class="input-box address">
        
          <input type="text" placeholder="Enter street address" onChange={(event) => {
                  setTraveller({ ...traveller, "address": event.target.value });
                }}  required />
          
        </div>
        <div class="input-box password">
        
          <input type="text" placeholder="Enter new password" onChange={(event) => {
                  setTraveller({ ...traveller, "passwordClear": event.target.value });
                }}  required />
          
        </div>
        <div class="gender-box">
          <h3>Gender</h3>
          <div class="gender-option">
            <div class="gender">
              <input type="radio" id="check-male" name="gender" checked={traveller.gender === "male"}
        onChange={() => {
          setTraveller({ ...traveller, gender: "male" });
        }} />
              <label className='genderlabel' htmlFor="check-male">male</label>
            </div>
            <div class="gender">
              <input type="radio" id="check-female" name="gender" checked={traveller.gender === "female"}
        onChange={() => {
          setTraveller({ ...traveller, gender: "female" });
        }}/>
              <label className='genderlabel' for="check-female">Female</label>
            </div>
            <div class="gender">
              <input type="radio" id="check-other" name="gender" checked={traveller.gender === "prefer-not-to-say"}
        onChange={() => {
          setTraveller({ ...traveller, gender: "prefer-not-to-say" });
        }} />
              <label className='genderlabel' for="check-other">prefer not to say</label>
            </div>
          </div>
        </div>
        <button className="traveller_register_btn" onClick={handleFormSubmit}>Submit</button>
        <ToastContainer />
        <div className="Account_login"><br/>
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
export default TravellerRegister;
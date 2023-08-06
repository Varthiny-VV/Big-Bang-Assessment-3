import React from "react";
import './AgentRegister.css';
import {Link} from "react-router-dom";

function AgentRegister(){
    return(
     
            <div className='tagent_register_body'>
            <body>
    <section class="container">
      <header className='registration_header'>Registration Form</header>
      <div action="#" class="form">
        <div class="input-box">
          <label>Your Name</label>
          <input type="text" placeholder="Enter full name" required />
        </div>
        <div class="input-box">
          <label>Agency Name</label>
          <input type="text" placeholder="Enter full name" required />
        </div>
        <div class="input-box">
          <label>Email Address</label>
          <input type="text" placeholder="Enter email address" required />
        </div>
        <div class="column">
          <div class="input-box">
            <label>Phone Number</label>
            <input type="number" placeholder="Enter phone number" required />
          </div>
          <div class="input-box">
            <label>Birth Date</label>
            <input type="date" placeholder="Enter birth date" required />
          </div>
        </div>
        
        <div class="input-box address">
          <label>Address</label>
          <input type="text" placeholder="Enter street address" required />
          
        </div>
        <div class="input-box address">
          <label>GST Number</label>
          <input type="text" placeholder="Enter street address" required />
          
        </div>
        <button>Submit</button>
        <div className="account_login">
        <p>
            Already have an account?{" "}
            <Link to="/login">Login here</Link>
          </p>
        </div>
      </div>
    </section>
  </body>
        </div>
        
    );
}

export default AgentRegister;
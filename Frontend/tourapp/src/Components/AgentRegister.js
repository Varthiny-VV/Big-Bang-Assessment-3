import React from "react";
import './AgentRegister.css';
import {Link} from "react-router-dom";

function AgentRegister(){
    return(
     
            <div className='agent_register_body'>
            <body>
    <div class="agent_container">
      <header className='registration_header'>Registration Form</header>
      <div action="#" class="agent_register_form">
        <div class="input-box">
         
          <input type="text" placeholder="Enter full name" required />
        </div>
        <div class="input-box">
          
          <input type="text" placeholder="Enter full name" required />
        </div>
        <div class="input-box">
          
          <input type="text" placeholder="Enter email address" required />
        </div>
        <div class="column">
          <div class="input-box">
           
            <input type="number" placeholder="Enter phone number" required />
          </div>
          <div class="input-box">
            
            <input type="date" placeholder="Enter birth date" required />
          </div>
        </div>
        
        <div class="input-box address">
          
          <input type="text" placeholder="Enter street address" required />
          
        </div>
        <div class="input-box address">
      
          <input type="text" placeholder="Enter GST Number" required />
          
        </div>
        <button>Submit</button>
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
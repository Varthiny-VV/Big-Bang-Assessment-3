import React from "react";
import './TravellerRegister.css';
import {Link} from "react-router-dom";

function TravellerRegister(){
    return(
        <div className='traveller_register_body'>
            <body>
    <div class="traveller_container">
      <header className='registration_header'>Registration Form</header>
      <div action="#" class="traveller_register_form">
        <div class="input-box">
          
          <input type="text" placeholder="Enter full name" required />
        </div>
        <div class="input-box">
       
          <input type="text" placeholder="Enter email address" required />
        </div>
        <div class="traveller_column">
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
        <div class="gender-box">
          <h3>Gender</h3>
          <div class="gender-option">
            <div class="gender">
              <input type="radio" id="check-male" name="gender" checked />
              <label className='genderlabel' for="check-male">male</label>
            </div>
            <div class="gender">
              <input type="radio" id="check-female" name="gender" />
              <label className='genderlabel' for="check-female">Female</label>
            </div>
            <div class="gender">
              <input type="radio" id="check-other" name="gender" />
              <label className='genderlabel' for="check-other">prefer not to say</label>
            </div>
          </div>
        </div>
        <button className="traveller_register_btn">Submit</button>
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
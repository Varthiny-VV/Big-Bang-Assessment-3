import React from "react";
import './TravellerRegister.css';

function TravellerRegister(){
    return(
        <div className='agent_register_body'>
            <body>
    <section class="container">
      <header className='registration_header'>Registration Form</header>
      <div action="#" class="form">
        <div class="input-box">
          <label>Full Name</label>
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
        <button>Submit</button>
      </div>
    </section>
  </body>
        </div>
    );
}
export default TravellerRegister;
import React from 'react';
import './LandingPage.css';
import { Link } from 'react-router-dom';

function LandingPage(){
    return(
        <div className='Landing-body'>
             <div class="glass">
        <nav>
            <h2 class="logo">T||A</h2>
            <ul>
                <li><Link to="/homepage">HOME</Link></li>
                <li><Link to="/login">ADMIN</Link></li>
                <li><Link to="/login">TRAVELLER</Link></li>
                <li><Link to="/login">TRAVEL AGENT</Link></li>
                <li><Link to="/contactus">CONTACT US</Link></li>
            </ul>
            {/* <img src={process.env.PUBLIC_URL + '/images/profile.jpeg' } alt="profile" className='landing_img'/> */}
        </nav>

        <div>
            <h3 className='landing_h3'>it's time to</h3>
            <h1 className='landing_h1'>TRAVEL</h1>
        </div>
       <div class="icons">
           <ul>
               <li><i class="fab fa-twitter"></i></li>
               <li><i class="fab fa-whatsapp"></i></li>
               <li><i class="fab fa-instagram"></i></li>
           </ul>
       </div>
    </div>

        </div>
    );
}

export default LandingPage;
import React from 'react';
import './LandingPage.css';

function LandingPage(){
    return(
        <div className='Landing-body'>
             <div class="glass">
        <nav>
            <h2 class="logo">T||A</h2>
            <ul>
                <li><a href="#">HOME</a></li>
                <li><a href="#">ABOUT</a></li>
                <li><a href="#">SERVICE</a></li>
                <li><a href="#">CONTACT</a></li>
            </ul>
            <img src={process.env.PUBLIC_URL + '/images/profile.jpeg'} alt="profile"/>
        </nav>

        <div>
            <h3>it's time to</h3>
            <h1>TRAVEL</h1>
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
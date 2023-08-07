import React from 'react';
import './SignInSignUp.css';
import { Link } from 'react-router-dom';

function SignInSignUp(){
    const navigate = usenavigate();
    var[user,setuser] = useSate({
        name:"",
        password:"",
    })
    return(
        <div className='signin-body'>
    <div class="sign_in_background"></div>
    <div class="sign_in_container">
        <div class="item">
            <h2 class="signin-logo"><i class='bx bxl-xing'></i>T||A</h2>
            <div class="text-item">
                <h2>Welcome <br/><span>
                 To the gateway of travel!
                </span></h2>
                <p>"Get ready to discover new horizons! Join now and let the adventures take flight."</p>
                <div class="social-icon">
                    <a href="#"><i class='bx bxl-facebook'></i></a>
                    <a href="#"><i class='bx bxl-twitter'></i></a>
                    <a href="#"><i class='bx bxl-youtube'></i></a>
                    <a href="#"><i class='bx bxl-instagram'></i></a>
                    <a href="#"><i class='bx bxl-linkedin'></i></a>
                </div>
            </div>
        </div>
        <div class="login-section">
            <div class="form-box login">
                <div action="">
                    <h2>Sign In</h2>
                    <div class="input-box">
                        <span class="icon"><i class='bx bxs-envelope'></i></span>
                        <input type="email" required/>
                        <label >Email</label>
                    </div>
                    <div class="input-box">
                        <span class="icon"><i class='bx bxs-lock-alt' ></i></span>
                        <input type="password" required/>
                        <label>Password</label>
                    </div>
                    <div class="remember-password">
                        <label for=""><input type="checkbox"/>Remember Me</label>
                        <a href="#">Forget Password</a>
                    </div>
                    <button class="login_btn">Login In</button>
                    <div class="create-account">
                        <p>Create A New Traveller Account? <Link to="/traveller" class="register-link">Sign Up</Link></p>
                        <p>Create A New Agent Account? <Link to="/travelagent" class="register-link">Sign Up</Link></p><br/>
                        
                    </div>
                </div>
            </div>
            

        </div>
    </div>
     

        </div>
    );
}

export default SignInSignUp;

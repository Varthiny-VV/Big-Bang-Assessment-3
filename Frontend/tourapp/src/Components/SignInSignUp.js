import React, { useState } from "react";
import './SignInSignUp.css';
import { Link, useNavigate } from "react-router-dom";

function SignInSignUp(){
    const navigate = useNavigate();
    var[user,setUser] = useState({
        emailId:"",
        password:"",
    });

    var login = () => {
        fetch("http://localhost:5210/api/User/Login", {
          method: "POST",
          headers: {
            accept: "text/plain", 
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ ...user }),
        })
          .then(async (data) => {
            var myData = await data.json();
            localStorage.setItem("emailId", myData.emailId);
            localStorage.setItem("role", myData.role);
            localStorage.setItem("token",myData.token);
            
            if (myData.role == "Admin") {
              // localStorage.setItem("managerId", myData.managerID);
              navigate("/adminmenu");
            } else if (myData.role == "Traveller") {
              navigate("/travellerLanding");
            }
            else if (myData.role == "Agent") {
              navigate("/viewpacks");
            }
          })
          .catch((err) => {
            console.log(err.error);
          });
        };
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
                        <input type="email"  onChange={(event) => {
                setUser({ ...user, emailId: event.target.value });
              }}  required/>
                        <label >Email</label>
                    </div>
                    <div class="input-box">
                        <span class="icon"><i class='bx bxs-lock-alt' ></i></span>
                        <input type="password"  onChange={(event) => {
                setUser({ ...user, password: event.target.value });
              }} required/>
                        <label>Password</label>
                    </div>
                    <div class="remember-password">
                        <label for=""><input type="checkbox"/>Remember Me</label>
                        <a href="#">Forget Password</a>
                    </div>
                    <button class="login_btn" onClick={login}>Login In</button>
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

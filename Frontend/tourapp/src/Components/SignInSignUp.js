import React from 'react';
import './SignInSignUp.css';

function SignInSignUp(){
    const handleRegisterClick = () => {
        const loginSection = document.querySelector('.login-section');
        loginSection.classList.add('active');
    };

    const handleLoginClick = () => {
        const loginSection = document.querySelector('.login-section');
        loginSection.classList.remove('active');
    };
    return(
        <div className='signin-body'>
            <header className='header'>
            <nav >
            {/* <h2 class="logo">T||A</h2> */}
            <ul>
                <li><a href="#">HOME</a></li>
                <li><a href="#">ABOUT</a></li>
                <li><a href="#">SERVICE</a></li>
                <li><a href="#">CONTACT</a></li>
            </ul>
            <img src={process.env.PUBLIC_URL + '/images/profile.jpeg'} alt="profile"/>
        </nav>
        {/* <form action="" class="search-bar">
       <input type="text" placeholder="Search..."/>
       <button><i class='bx bx-search'></i></button>
    </form> */}
            </header>
    <div class="background"></div>
    <div class="container">
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
                <form action="">
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
                    <button class="btn">Login In</button>
                    <div class="create-account">
                        <p>Create A New Traveller Account? <a href="#" class="register-link" onClick={handleRegisterClick}>Sign Up</a></p><br/>
                        
                    </div>
                </form>
            </div>
            <div class="form-box register">
                <form action="">

                    <h2>Sign Up</h2>

                    <div class="input-box">
                        <span class="icon"><i class='bx bxs-user'></i></span>
                        <input type="text" required/>
                        <label >Username</label>
                    </div>
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
                        <label for=""><input type="checkbox"/>I agree with this statment</label>
                    </div>
                    <button class="btn">Login In</button>
                    <div class="create-account">
                        <p>Already Have An Account? <a href="#" class="login-link" onClick={handleLoginClick}>Sign In</a></p>
                        
                    </div>
                </form>
            </div>

        </div>
    </div>
     

        </div>
    );
}

export default SignInSignUp;

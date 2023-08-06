import React from "react";
import './ContactUs.css';

function ContactUs(){
    return(
        <div className="contact-body">
            <div class="bg-background"></div>
        <div class="container py-5">
            <div class="row py-5 g-3">    
                <div class="col-md-6 first_col ">
                    <h1 class="text-center mt-3">Contact Us</h1>
                    <form class="p-4 mt-5">
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Enter your Name</label>
                            <input type="text" class="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlInput1" class="form-label">Email ID</label>
                            <input type="text" class="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div class="mb-3">
                            <label for="exampleFormControlTextarea1" class="form-label">Enter your massage</label>
                            <textarea  type="text" class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                        </div>
                        <div class="mb-3">
                            <button class="btn btn-primary">Send Now</button>
                        </div>
                    </form>
                </div>
                <div class="col-md-6 sec_col">
                    <img src={process.env.PUBLIC_URL + '/images/ContactUS.jpg'}
                        class="img-fluid"/>
                </div>
            </div>
            <div class="row-last">
                <div class="row row-cols-1 row-cols-md-3  p-3 text-white">
                    <div class="col">
                        <h4>CALL US</h4>
                        <p><i class="ri-phone-line"></i> 6382364551</p>

                    </div>
                    <div class="col">
                        <h4>LOCATION</h4>
                        <h6><i class="ri-map-pin-line"></i> KANINI SOFTWARE SOLUTIONS,CHENNAI</h6>
                        
                    </div>
                    <div class="col">
                        <h4>Email</h4>
                        <p><i class="ri-mail-line"></i> vv@gamil.com</p>
                    </div>
                </div>
            </div>
        </div>
        </div>
        
    
    );
}

export default ContactUs;
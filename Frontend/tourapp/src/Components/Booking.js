import React, { useState, useEffect } from "react";
import './Booking.css';
import html2pdf from "html2pdf.js";
import html2canvas from "html2canvas";


function Booking(){
    var [agent, setAgent] = useState({
       
            
        travellerEmail: "",
        travellerCount: "",
        pickUp: "",
        drop: "",
           
    });

    const [registrationStatus, setRegistrationStatus] = useState(null);
useEffect(() => {
  if (registrationStatus === "registering") {
    // Make the API call here
    fetch("http://localhost:5259/api/Booking/AddReservation", {
      method: "POST",
      headers: {
        accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(agent),
    })
      .then(async (response) => {
        if (response.ok) {
          setRegistrationStatus("success");
          console.log(response);
        } else {
          throw new Error("Error registering agent");
        }
      })
      .catch((error) => {
        console.log(error);
        setRegistrationStatus("error");
      });
  }
}, [registrationStatus, agent]);

const handleFormSubmit = (event) => {
  event.preventDefault();
  setRegistrationStatus("registering");
  handleDownloadPDF()
};
const handleDownloadPDF = () => {
  const input = document.getElementById("pdf-down");
  const pdfOptions = {
    margin: [10, 10],
    filename: "my_component.pdf",
    image: { type: "jpeg", quality: 0.98 },
    html2canvas: { scale: 2 },
    jsPDF: { unit: "mm", format: "a4", orientation: "portrait" },
  };

  html2canvas(input).then((canvas) => {
    const pdf = new html2pdf().from(canvas).set(pdfOptions).save();
  });
}
    return(
        <div className='traveller_register_body'>
            <body>
    <div class="traveller_container"id="pdf-down">
      <header className='registration_header'>Booking Registration Form</header>
      <div action="#" class="traveller_register_form">
      <div class="input-box">
       
       <input type="text" placeholder="Enter email address" requiredonChange={(event) => {
               setAgent({ ...agent, "travellerEmail": event.target.value });
             }}required />
     </div>
        <div class="input-box">
          
          <input type="int" placeholder="Traveller Count" onChange={(event) => {
                  setAgent({ ...agent, "travellerCount": event.target.value });
                }}required />
        </div>
        
        <div class="traveller_column">
          <div class="input-box">
           
            <input type="text" placeholder="pickup location" onChange={(event) => {
                  setAgent({ ...agent, "pickUp": event.target.value });
                }}required />
          </div>
          <div class="input-box">
           
            <input type="text" placeholder="Drop location" onChange={(event) => {
                  setAgent({ ...agent, "drop": event.target.value });
                }}requiredrequired />
          </div>
        </div>
        
        
       
        <button className="traveller_register_btn" onClick={handleDownloadPDF}  
>Submit</button>
        
      </div>
    </div>
   
  </body>
        </div>
    );
}

export default Booking;
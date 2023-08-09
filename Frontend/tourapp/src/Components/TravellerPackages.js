import React, { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import html2pdf from "html2pdf.js";
import html2canvas from "html2canvas";
import './TravellerPackages.css';


function TravellerPackages(props){
    const [pack, setPack] = useState([props.user]);
    useEffect(() => {
        if (pack[0]) {
          localStorage.setItem("packageId", pack[0].packageId);
        }
      }, [pack]);
      const navigate = useNavigate();
      var booknow = () => {
    
        navigate("/booking");
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
        <div className="traveller_package">
            <div className="card card-body IndividualDoctor card text-white bg-dark mb-3 shadow p-3 mb-5 rounded" id="pdf-down">
        <h5 className="card-title">{pack[0].packageName}</h5>
       
        <br />
        <p className="card-text">
          <b>Destination -</b>
          {pack[0].destination}
        </p>
        <p className="card-text">
          <b>Description</b>
          {pack[0].description}
        </p>
        <p className="card-text">
          <b>Price - Rs. </b>
          {pack[0].price}
        </p>
        <p className="card-text">
          <b>From -  </b>
          {pack[0].startDate}
        </p>
        <p className="card-text">
          <b>To -  </b>
          {pack[0].endDate}
        </p>
        <p className="card-text">
          <b> Duration - </b>
          {pack[0].duration}
        </p>     
        <p className="card-text">
          <b>Transportation - </b>
          {pack[0].transportation}
        </p>   
        <p className="card-text">
          <b>Available - </b>
          {pack[0].availabilityCount}
        </p>
        </div>
        <button className="card-link btn btn-secondary" onClick={handleDownloadPDF}>
         Book Now
        </button>
        
        </div>
    )
}

export default TravellerPackages;
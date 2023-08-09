import React, { useState, useEffect } from "react";


function IndividualPacks(props){
    const [pack, setPack] = useState([props.user]);
    useEffect(() => {
        if (pack[0]) {
          localStorage.setItem("packageId", pack[0].packageId);
        }
      }, [pack]);
    return(
        <div>
            <div className="card card-body IndividualDoctor card text-white bg-dark mb-3 shadow p-3 mb-5 rounded">
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
        </div>
    )
}

export default IndividualPacks;
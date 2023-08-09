import { useState,useCallback ,useEffect} from "react";

import AdminMenu from "./AdminMenu";
import ApproveAgents from "./ApproveAgents";
// import "./ViewEmployee.css";

function ViewAgents() {
  var[agents,setagents]=useState([]);
  const [id, setId] = useState("");
  const [isApproved, setIsApproved] = useState("");

  useEffect(()=>{
    getAgents();
  },[]);

  // var [active, setData] = useState([]);
  // useEffect(() => {
  //   GetAllAgents();
  // }, []);

  const getAgents = () => {
    fetch(
      "http://localhost:5210/api/User/GetAllAgents",
      {
        method: "GET",
        headers: {
          accept: "text/plain",
          "Content-Type": "application/json",
          
        },
      }
    )
    .then(async (response) => {
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      const myData = await response.json();
      console.log(myData);
      setagents(myData);
      console.log(agents);
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });
    }


  return (
    <div>
      
      <AdminMenu />
      <div className="GetAll">
      {
        agents.map((agent,index)=>{
        return(<ApproveAgents key={index} user = {agent}/>)
      })
     }
      </div>
    </div>
  );
}
export default ViewAgents;

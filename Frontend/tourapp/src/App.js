import logo from './logo.svg';
import './App.css';
import "bootstrap/dist/css/bootstrap.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from './Components/HomePage';
import LandingPage from './Components/LandingPage';
import TravellerRegister from './Components/TravellerRegister';
import AgentRegister from './Components/AgentRegister';
import ContactUs from './Components/ContactUs';
import SignInSignUp from './Components/SignInSignUp';


function App() {
  return (
    <div className="App">


        <BrowserRouter>
        <Routes>
        <Route path="/" element={<HomePage/>} />
        <Route path="/landing" element={<LandingPage/>} />
        <Route path="/traveller" element={<TravellerRegister/>} />
        <Route path="/travelagent" element={<AgentRegister/>} />
        <Route path="/contactus" element={<ContactUs/>} />
        <Route path="/login" element={<SignInSignUp/>} />



        </Routes>
        </BrowserRouter>
      {/* <LandingPage></LandingPage> */}
      {/* <SignInSignUp></SignInSignUp> */}
       {/* <HomePage></HomePage>  */}
      {/* <ContactUs></ContactUs> */}
      {/* <AgentRegister></AgentRegister> */}
      {/* <TravellerRegister></TravellerRegister> */}
    </div>
  );
}

export default App;

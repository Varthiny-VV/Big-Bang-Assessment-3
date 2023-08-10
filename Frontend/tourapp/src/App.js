import logo from './logo.svg';
import './App.css';
import "bootstrap/dist/css/bootstrap.css";
import 'react-toastify/dist/ReactToastify.css';
import 'react-responsive-carousel/lib/styles/carousel.min.css'
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from './Components/HomePage';
import LandingPage from './Components/LandingPage';
import TravellerRegister from './Components/TravellerRegister';
import AgentRegister from './Components/AgentRegister';
import ContactUs from './Components/ContactUs';
import SignInSignUp from './Components/SignInSignUp';
import AdminMenu from './Components/AdminMenu';
import ViewAgents from './Components/ViewAgents';
import ApproveAgents from './Components/ApproveAgents';
import ViewPackages from './Components/ViewPackages';
import PackageForm from './Components/PackageForm';
import TravellerLanding from './Components/TravellerLanding';
import ProtectedRoutes from './Components/ProtectedRoutes/Protected';
function App() {
  return (
    <div className="App">


        <BrowserRouter>
        <Routes>
        <Route path="/" element={<HomePage/>} />
        <Route path="/homepage" element={<HomePage/>} />
        <Route path="/landing" element={<LandingPage/>} />
        <Route path="/traveller" element={<TravellerRegister/>} />
        <Route path="/travelagent" element={<AgentRegister/>} />
        <Route path="/contactus" element={<ContactUs/>} />
        <Route path="/login" element={<SignInSignUp/>} />  
        <Route path="/adminmenu" element={<AdminMenu/>} />
        <Route path="/viewagents" element={<ViewAgents/>} /> 
        <Route path="/approveagents" element={<ApproveAgents/>} />
        <Route path="/viewPacks" element={<ViewPackages/>}/>
        <Route path="/addPack" element={<PackageForm/>}/>       
        <Route path="/travellerLanding" element={<TravellerLanding/>}/>
        
            
        <Route element={<ProtectedRoutes allowedRoles={["Traveller"]} />}>
            
            <Route path="/travellerLanding" element={<TravellerLanding/>}/>
            <Route element={<ProtectedRoutes allowedRoles={["Admin"]} />}>
            <Route path="/adminmenu" element={<AdminMenu/>} />
            <Route path="/viewagents" element={<ViewAgents/>} />
            </Route>
          </Route>


        </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;

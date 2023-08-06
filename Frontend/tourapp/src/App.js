import logo from './logo.svg';
import './App.css';
import "bootstrap/dist/css/bootstrap.css";
// import AgentRegister from './Components/AgentRegister';
// import TravellerRegister from './Components/TravellerRegister';
// import ContactUs from './Components/ContactUs';
//  import LandingPage from './Components/LandingPage';
import SignInSignUp from './Components/SignInSignUp';
//import HomePage from './Components/HomePage';

function App() {
  return (
    <div className="App">
      {/* <LandingPage></LandingPage> */}
      <SignInSignUp></SignInSignUp>
      {/* <HomePage></HomePage> */}
      {/* <ContactUs></ContactUs> */}
      {/* <AgentRegister></AgentRegister> */}
      {/* <TravellerRegister></TravellerRegister> */}
    </div>
  );
}

export default App;

import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>

);

// const loginsec=document.querySelector('.login-section')
// const loginlink=document.querySelector('.login-link')
// const registerlink=document.querySelector('.register-link')
// registerlink.addEventListener('click',()=>{
//     loginsec.classList.add('active')
// })
// loginlink.addEventListener('click',()=>{
//     loginsec.classList.remove('active')
// })

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

import React, { useState, useEffect } from 'react';
import './HomePage.css';
import ScrollReveal from 'scrollreveal';
import { Link } from 'react-router-dom';

function HomePage(){
   const [showMenu, setShowMenu] = useState(false);

  const handleToggleMenu = () => {
    setShowMenu(!showMenu);
  };

  const handleCloseMenu = () => {
    setShowMenu(false);
  };

  const handleNavLinkClick = () => {
    setShowMenu(false);
  };

  const [blurHeader, setBlurHeader] = useState(false);

  const handleScroll = () => {
    setBlurHeader(window.scrollY >= 50);
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll);
    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);
  const handleScrollUp = () => {
   window.scrollTo({
     top: 0,
     behavior: 'smooth',
   });
 };

 useEffect(() => {
   const scrollUpButton = document.getElementById('scroll-up');

   const handleScroll = () => {
     scrollUpButton.style.display = window.scrollY >= 350 ? 'block' : 'none';
   };

   window.addEventListener('scroll', handleScroll);

   return () => {
     window.removeEventListener('scroll', handleScroll);
   };
 }, []);
 const [activeSection, setActiveSection] = useState('');

  const handleActiveSection = () => {
    const scrollDown = window.scrollY;
    const sections = document.querySelectorAll('section[id]'); // Define 'sections' here

    sections.forEach((current) => {
      const sectionHeight = current.offsetHeight;
      const sectionTop = current.offsetTop - 58;
      const sectionId = current.getAttribute('id');

      if (scrollDown > sectionTop && scrollDown <= sectionTop + sectionHeight) {
        setActiveSection(sectionId);
      }
    });
  };

  useEffect(() => {
    window.addEventListener('scroll', handleActiveSection);

    return () => {
      window.removeEventListener('scroll', handleActiveSection);
    };
  }, []);

  useEffect(() => {
   // Initialize ScrollReveal
   const sr = ScrollReveal({
     origin: 'top',
     distance: '60px',
     duration: 3000,
     delay: 400,
   });

   // Define the elements you want to animate
   const elementsToAnimate = [
     '.home__data',
     '.explore__data',
     '.explore__user',
     '.footer__container',
   ];

   const homeCards = document.querySelectorAll('.home__card');
   const aboutData = document.querySelector('.about__data');
   const joinImage = document.querySelector('.join__image');

   // Apply the animations to the elements
   sr.reveal(elementsToAnimate.join(', '));
   sr.reveal(homeCards, { delay: 600, distance: '100px', interval: 100 });
   sr.reveal(aboutData, { origin: 'right' });
   sr.reveal(joinImage, { origin: 'left' });
   sr.reveal('.popular__card', { interval: 200 });

   // Clean up ScrollReveal on component unmount
   return () => {
     sr.destroy();
   };
 }, []);
 
  
    return(
       <html className='home__html'>
           <body className='home__body'>
      {/* <!--==================== HEADER ====================--> */}
      <header class={`header ${blurHeader ? 'blur-header' : ''}`} id="header">
         <nav class="nav nav_container">
            <a href="#" class="nav__logo">
              &nbsp; &nbsp; &nbsp;KANINI TOURISM
            </a>

            <div class={`nav__menu ${showMenu ? 'show-menu' : ''}`} id="nav-menu">
               <ul class="nav__list">
                  <li class={`nav__item ${activeSection === 'home' ? 'active-link' : ''}`}>
                     <a href="#home" class="nav__link active-link" onClick={handleNavLinkClick}>Home</a>
                  </li>

                  <li class={`nav__item ${activeSection === 'about' ? 'active-link' : ''}`}>
                     <a href="#about" class="nav__link" onClick={handleNavLinkClick}>About</a>
                  </li>

                  <li class={`nav__item ${activeSection === 'popular' ? 'active-link' : ''}`}>
                     <a href="#popular" class="nav__link"  onClick={handleNavLinkClick}>Popular</a>
                  </li>

                  <li class={`nav__item ${activeSection === 'explore' ? 'active-link' : ''}`}>
                     <a href="#explore" class="nav__link" onClick={handleNavLinkClick}>Explore</a>
                  </li>
               </ul>

               <div class="nav__close" id="nav-close" onClick={handleCloseMenu}>
                  <i class="ri-close-line"></i>
               </div>
            </div>

            <div class="nav__toggle" id="nav-toggle" onClick={handleToggleMenu}>
               <i class="ri-menu-fill"></i>
            </div>
         </nav>
      </header>
{/* 
      <!--==================== MAIN ====================--> */}
      <main class="main">
         {/* <!--==================== HOME ====================--> */}
         <section class="home section" id="home">
            <img src={process.env.PUBLIC_URL + '/images/home-bg.jpg'} alt="" class="home__bg home__img"></img>
            <div className="home__shadow"></div>
            <div className="home__container home_container grid">
               <div className="home__data">
                 <h3 className="home__subtitle">
                  Welcome To Travel
                  </h3> 
                  <h1 className="home__title">
                     Explore <br/>
                     The World
                  </h1>
                  <p className='home__description'>
                     Live the trips exploring the world, discover
                     paradises, islands, mountains and much 
                     more, get your trip now.
                  </p>
                  <Link to="/landing" className="button">Start Your Journey <i className="ri-arrow-right-line"></i></Link>
               </div>
               <div className='home__cards grid'>
                  <article className='home__card'>
                     <img src={process.env.PUBLIC_URL + '/images/Dubai.jpg'} alt="" className='home__card-img home__img'></img>
                     <h3 className='home__card-title'>India</h3>
                     <div className='home__card-shadow'></div>
                  </article>

                  <article className='home__card'>
                     <img src={process.env.PUBLIC_URL + '/images/Paris.jpg'} alt="" className='home__card-img home__img'></img>
                     <h3 className='home__card-title'>Paris</h3>
                     <div className='home__card-shadow'></div>
                  </article>

                  <article className='home__card'>
                     <img src={process.env.PUBLIC_URL + '/images/Italy.jpg'} alt="" className='home__card-img home__img'></img>
                     <h3 className='home__card-title'>Italy</h3>
                     <div className='home__card-shadow'></div>
                  </article>

                  <article className='home__card'>
                     <img src={process.env.PUBLIC_URL + '/images/ROme.jpg'} alt="" className='home__card-img home__img'></img>
                     <h3 className='home__card-title'>Rome</h3>
                     <div className='home__card-shadow'></div>
                  </article>
               </div>
            </div>

         </section>

         {/* <!--==================== ABOUT ====================--> */}
         <section class="about section" id="about">
            <div className='about section' id='about'>
               <div className='about__container home_container grid'>
                  <div className='about__data'>
                     <h2 className='section__title'>
                        Learn More <br/>
                        About Travel
                     </h2>
                     <p className='about__description'>
                        All the trips around the world are a great 
                        pleasure and happiness for anyone, enjoy 
                        the sights when you travel the world. Travel 
                        safely and without worries, get your trip and 
                        explore the paradises of the world.

                     </p>
                     <a href='#' className='button'>
                        Explore Travel <i className="ri-arrow-right-line"></i>

                     </a>
                  </div>
                  <div className='about__image'>
                     <img src={process.env.PUBLIC_URL + '/images/About.jpg'} alt='' className='about__img home__img'></img>
                     <div className='about__shadow'></div>
                  </div>
               </div>
            </div>
         </section>

         {/* <!--==================== POPULAR ====================--> */}
         <section class="popular section" id="popular">
            <h2 className='section__title'>
               Enjoy The Beauty <br/>
               Of The World

            </h2>
            <div className='popular__container container grid'>
         <article className='popular__card'>
            <div className='popular__image'>
               <img src={process.env.PUBLIC_URL + '/images/Switzerland.jpg'} alt='' className='popular__img home__img'></img>
               <div className='popular__shadow'></div>
            </div>
            <h2 className='popular__title'>
            Raten Pass

            </h2>
            <div className='popular__location'>
               <i className='ri-map-pin-line'></i>
               <span>Switzerland</span>
            </div>
         </article>

         <article className='popular__card'>
            <div className='popular__image'>
               <img src={process.env.PUBLIC_URL + '/images/Singapore.jpg'} alt='' className='popular__img home__img'></img>
               <div className='popular__shadow'></div>
            </div>
            <h2 className='popular__title'>
            Marina Bay Sands

            </h2>
            <div className='popular__location'>
               <i className='ri-map-pin-line'></i>
               <span>Singapore</span>
            </div>
         </article>

         <article className='popular__card'>
            <div className='popular__image'>
               <img src={process.env.PUBLIC_URL + '/images/Japan.jpg'} alt='' className='popular__img home__img'></img>
               <div className='popular__shadow'></div>
            </div>
            <h2 className='popular__title'>
               
               Red Wooden Temple

            </h2>
            <div className='popular__location'>
               <i className='ri-map-pin-line'></i>
               <span>Japan</span>
            </div>
         </article>
                
            </div>
         </section>
         
         {/* <!--==================== EXPLORE ====================--> */}
         <section class="explore section" id="explore">
            <div className='explore__container'>
               <div className='explore__image'>
                  <img src={process.env.PUBLIC_URL + '/images/explore.jpg'} alt='' className='explore__img home__img'></img>
                  <div className='explore__shadow'></div>
                  </div>
              <div className='explore__content container grid'>
               <div className='explore__data'>
                  <h2 className='section__title'>
                     Explore The<br/>
                     Best Paradises
                  </h2>
                  <p className='explore__description'>
                  Exploring paradises such as islands and 
                  valleys when traveling the world is one of 
                  the greatest experiences when you travel, it 
                  offers you harmony and peace and you 
                  can enjoy it with great comfort.
                  </p>
               </div>
               <div className='explore__user'>
                  <img src={process.env.PUBLIC_URL + '/images/profile.jpeg'} alt='' className='explore__profile home__img'></img>
                  <span class="explore__name">VV</span>
               </div>
              </div>
            </div>
         </section>
         
         {/* <!--==================== JOIN ====================--> */}
         <section class="join section">
            <div className='join__container container grid'>
               <div className='join__data'>
                  <h2 className='section__title'>
                     Your Journey<br/>
                     Starts Here
                  </h2>
                  <p className='join__description'>
                     Get up to date with the latest travel and information from us.
                  </p>
                  <div actions='' className='join__from'>
                     <input type='email' placeholder='Enter your email' className="join__input home__img"></input>
                     <button className='join__button button'>
                        Subscribe Our Newsletter<i className='ri-arrow-right-line'></i>
                     </button>
                  </div>
               </div>
               <div className='join__image'>
                  <img src={process.env.PUBLIC_URL + '/images/join.jpg'} alt='' className='join__img home__img'></img>
                  <div className='join__shadow'></div>
               </div>
            </div>
         </section>
      </main>

      {/* <!--==================== FOOTER ====================--> */}
      <footer class="footer">
        <div className='footer__container container grid'>
         <div className='footer__content grid'>
            <div>
               <a href='#' className='footer__logo'>T||A</a>
               <p className='footer__description'>
                  Travel with us and explore <br/>
                  the world without limits.
               </p>
            </div>
            <div className='footer__data grid'>
               <div>
                  <h3 className='footer__title'>About</h3>
                  <ul className='footer__links'>
                     <li>
                        <a href='#' className='footer__link'>About Us</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>Features</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>News & Blogs</a>
                     </li>
                  </ul>
               </div>

               <div>
                  <h3 className='footer__title'>Company</h3>
                  <ul className='footer__links'>
                     <li>
                        <a href='#' className='footer__link'>FAQs</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>History</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>Testimonials</a>
                     </li>
                  </ul>
               </div>

               <div>
                  <h3 className='footer__title'>Contact</h3>
                  <ul className='footer__links'>
                     <li>
                        <a href='#' className='footer__link'>Call Center</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>Support Center</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>Contact Us</a>
                     </li>
                  </ul>
               </div>

               <div>
                  <h3 className='footer__title'>Support</h3>
                  <ul className='footer__links'>
                     <li>
                        <a href='#' className='footer__link'>Privacy Policy</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>Terms & Services</a>
                     </li>
                     <li>
                        <a href='#' className='footer__link'>Payments</a>
                     </li>
                  </ul>
               </div>
            </div>
         </div>
         <div className='footer__group'>
            <div className='footer__social'>
               <a href="https://www.facebook.com/" target='_blank' className='footer__social-link'>
               <i class="ri-facebook-line"></i> </a>

               <a href='"https://www.instagram.com/"' target='_blank' className='footer__social-link'>
               <i class="ri-instagram-line"></i>
               </a>

               <a href='"https://twitter.com/"' target='_blank' className='footer__social-link'>
               <i class="ri-twitter-line"></i>
               </a>

               <a href='"https://www.youtube.com/"' target='_blank' className='footer__social-link'>
               <i class="ri-youtube-line"></i>
               </a>
            </div>
            <span className='footer__copy'>
               &#169; Copyright VVcode. All rights reserved
            </span>
         </div>
         </div> 
      </footer>

      {/* <!--========== SCROLL UP ==========--> */}
      <a href='#' className='scrollup show-scroll' id='scroll-up' onClick={handleScrollUp}>
         <i className="ri-arrow-up-line"></i>
      </a>

      {/* <!--=============== SCROLLREVEAL ===============--> */}
      <script src=""></script>

      {/* <!--=============== MAIN JS ===============--> */}
      <script src="main.js"></script>
   </body>
   </html>
   
    );
}

export default HomePage;
import React from 'react';

function HomePage(){
    return(
        <div className='html'>
            <div className='HomePage-body'>
                <header className='header' id='header'>
                    <nav className='nav container'>
                        <a href='#' className='nav__logo'>
                        T||A
                        </a>
                        <div className='nav__menu' id='nav-menu'>
                            <ul className='nav__list'>
                               <li class='nav__item'>
                                <a href='#home' className='nav__link'>Home</a>
                                </li> 
                                <li class='nav__item'>
                                <a href='#about' className='nav__link'>About</a>
                                </li> 
                                <li class='nav__item'>
                                <a href='#popular' className='nav__link'>Popular</a>
                                </li> 
                                <li class='nav__item'>
                                <a href='#explore' className='nav__link'>Explore</a>
                                </li> 
                            </ul>



















                            
                        </div>
                    </nav>

                </header>
                <main className='main'>

                </main>
                <footer className='footer'>

                </footer>
            </div>
        </div>
    );
}

export default HomePage;
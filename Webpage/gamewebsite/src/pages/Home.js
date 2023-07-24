import React from "react";
import {Link} from "react-router-dom";
import HomeBg from "../assets/HomeBg.png";
import "../styles/Home.css";

const Home = () => {
    return (
        <div className="home" style={{ backgroundImage: `url(${HomeBg})`}}>
            <div className="header-container">
                <h1> An original Tower Defense Game </h1>
                <p> By TowerPower </p>
                <Link to="/play">
                    <button> PLAY NOW </button>
                </Link>
            </div>
        </div>
    );
}

export default Home;
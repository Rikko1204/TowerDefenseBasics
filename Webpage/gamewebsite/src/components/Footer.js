import React from "react";
import "../styles/Footer.css";
import InstagramIcon from "@mui/icons-material/Instagram";
import TwitterIcon from "@mui/icons-material/Twitter";
import FacebookIcon from "@mui/icons-material/Facebook";
import LinkedInIcon from "@mui/icons-material/LinkedIn";

const Footer = () => {
    return (
        <div className="footer">
            <div className="social-media">  
                <a href={instagramLink} target="_blank" rel="noreferrer"> <InstagramIcon /> </a>
                <a href={instagramLink} target="_blank" rel="noreferrer"> <TwitterIcon /> </a>
                <a href={instagramLink} target="_blank" rel="noreferrer"> <FacebookIcon /> </a>
                <a href={instagramLink} target="_blank" rel="noreferrer"> <LinkedInIcon /> </a>
            </div>
            <p> &copy; PowerTower.com </p>
        </div>
    );
}

const instagramLink = "https://www.instagram.com/nusjss/";

export default Footer;
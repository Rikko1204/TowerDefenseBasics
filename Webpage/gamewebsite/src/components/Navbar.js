import React, {useState} from "react";
import {Link, resolvePath, useMatch} from 'react-router-dom';
import Cannon from "../assets/Cannon.png";
import "../styles/Navbar.css";
import ReorderIcon from '@mui/icons-material/Reorder';

const Navbar = () => {
    
    const [openLinks, setOpenLinks] = useState(false);

    const toggleNavbar = () => {
        setOpenLinks(!openLinks);
    }

    return (
        <div className="navbar">
            <div className="left-side" id={openLinks ? "open" : "false"}>
                <img src={Cannon}/>
                <div className="hidden-links">
                    <Link to="/"> Home </Link>
                    <Link to="/about"> About </Link>
                    <Link to="/play"> Play </Link>
                    <Link to="/authors"> Authors </Link>
                </div>
            </div>
            <div className="right-side">
                <Link to="/"> Home </Link>
                <Link to="/about"> About </Link>
                <Link to="/play"> Play </Link>
                <Link to="/authors"> Authors </Link>
                <button onClick={toggleNavbar}>
                    <ReorderIcon />
                </button>
            </div>
        </div>
    );
    
}

export default Navbar;

/*
const navbar = () => {
    return (
        <nav className="nav">
            <Link to="/" className="site-title">
                Site Name
            </Link>
            <ul>
                <CustomLink to="/authors" name="Authors"/>
                <CustomLink to="/about" name="About"/>
            </ul>
        </nav>
    );
}
export default navbar;

const CustomLink = ({to, name}) => {
    const resolvedPath = resolvePath(to);
    const isActivePage = useMatch({path: resolvedPath.pathname, end: true});

    return (
        <li className={isActivePage ? "active" : ""}>
            <Link to={to}>
                {name}
            </Link>
        </li>
    );
}
*/
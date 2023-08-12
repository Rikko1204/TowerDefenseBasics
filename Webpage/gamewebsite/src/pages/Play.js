import "../styles/Play.css";
import HomeBg from "../assets/HomeBg.png";
import Towers from "../assets/Towers.png";
import Enemies from "../assets/Enemies.png";
import MapBg from "../assets/MapBg.png";
import AlmanacBg from "../assets/AlmanacBg.png";

const Play = () => {
    return (
        <div className="play">
            <div className="background" style={{ backgroundImage: `url(${HomeBg})`}} >
                <a href={downloadLink} target="_blank" rel="noreferrer">                   
                    <button className="play-now-button"> 
                        PLAY NOW    
                    </button> 
                </a>
            </div>
            <div className="tower-section">        
                <img src={Towers} />
                <div className="description">
                    <h1> Build new towers </h1>
                    <p> Discover powerful new towers to mow down your opponents! </p>
                </div>
            </div>
            <div className="enemy-section">
                <div className="description">
                    <h1> Protect your base </h1>
                    <p> Defend against hoard of enemies, fight with all your might! </p>
                </div>
                <img src={Enemies} />
            </div>
            <div className="map-section">        
                <img src={MapBg} />
                <div className="description">
                    <h1> Test your skills </h1>
                    <p> What will you do when faced with increasingly stronger opponents? </p>
                </div>
            </div>
            <div className="almanac-section">
                <div className="description">
                    <h1> Review your strategies </h1>
                    <p> Equip yourself with knowledge and evolve your strategies! </p>
                </div>
                <img src={AlmanacBg} />
            </div>
        </div>
    );
}

const downloadLink = "https://drive.google.com/drive/folders/1tqebHllAqwG_U4GBDhiXpSdEwPOGJy5-?usp=sharing";
export default Play;
import AboutBg from "../assets/AboutBg.png";
import "../styles/About.css";
import { AuthorList } from "../helpers/AuthorList";
import AuthorInfo from "../components/AuthorInfo";

const About = () => {
    return (
        <div className="about">
            <div className="about-top" style={{ backgroundImage: `url(${AboutBg})`}}> </div>
            <div className="about-middle">
                <h1>
                    ABOUT US
                </h1>
                <p>
                    We are a team of students from National Univeristy of Singapore (NUS) with a shared love for
                    gaming and a vision to bring captivating experience to life. With a blend of innovative ideas 
                    and a strong foundation in game development, we are on a thrilling journey to craft immersive 
                    games that resonate with players of all ages.
                </p>
            </div>
            <div className="about-authors">
                {AuthorList.map((author, key) => {
                    return (
                        <AuthorInfo 
                        key={key}
                        name={author.name}
                        image={author.image}
                        description={author.description}
                        />
                    );
                })}
            </div>
        </div>
    );
}
export default About;
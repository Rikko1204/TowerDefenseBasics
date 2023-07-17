import {Link, resolvePath, useMatch} from 'react-router-dom';

const Navbar = () => {
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
export default Navbar;

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

const Navbar = () => {
    return (
        <nav className="nav">
            <a href="/" className="site-title">
                Site Name
            </a>
            <ul>
                <CustomLink href="/authors" name="Authors"/>
                <CustomLink href="/about" name="About"/>
            </ul>
        </nav>
    );
}
export default Navbar;

const CustomLink = ({href, name}) => {
    const path = window.location.pathname;
    return (
        <li className={path === href ? "active" : ""}>
            <a href={href}>
                {name}
            </a>
        </li>
    );
}

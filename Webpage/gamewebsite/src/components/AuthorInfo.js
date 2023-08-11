import React from "react";

const AuthorInfo = ({name, image, description}) => {
    return (
        <div className="author-info">
            <img src={image} />
            <h1> {name} </h1>
            <p> {description} </p>
        </div>
    );
}

export default AuthorInfo;
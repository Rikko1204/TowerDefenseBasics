import React from 'react';
import ContactBg from"../assets/ContactBg.png";
import "../styles/Contact.css";
import emailjs from "@emailjs/browser";
import Swal from "sweetalert2";

const Contact = () => {
    return (
        <div className='contact'>
            <div className='left-side'  style={{ backgroundImage: `url(${ContactBg})`}}>  </div>
            <div className='right-side'>
                <h1> Contact Us </h1>
                <form id="contact-form" method="POST" onSubmit={handleOnSubmit}>
                    <label htmlFor="name"> Name </label>
                    <input name="name" id="name" type="text" placeholder="Enter name..." required />
                    <label htmlFor="email"> Email </label>
                    <input name="email" id="email" type="email" placeholder="Enter email..." required />
                    <label htmlFor="message"> Message </label>
                    <textarea name="message" id="message" placeholder="Enter message..." rows={6} required />
                    <button type="submit"> Send Message </button>
                </form>
            </div>
        </div>
    );
}

const handleOnSubmit = (e) => {
    e.preventDefault();
    emailjs.sendForm(SERVICE_ID, TEMPLATE_ID, e.target, PUBLIC_KEY)
      .then((result) => {
        console.log(result.text);
        Swal.fire({
          icon: "success",
          title: "Message Sent Successfully"
        })
      }, (error) => {
        console.log(error.text);
        Swal.fire({
          icon: "error",
          title: "Ooops, something went wrong",
          text: error.text,
        })
      });
    e.target.reset()
  };

const SERVICE_ID = "service_ldkpu9m";
const TEMPLATE_ID = "template_3a2vrq7";
const PUBLIC_KEY = "ym2DLzrXYgKMJRvch";

export default Contact;
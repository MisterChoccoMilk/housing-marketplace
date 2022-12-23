import React from "react";
import "./Footer.css";

function Footer() {
  return (
    <div className="footer-container">
      <section className="footer-info">
        <p className="footer-info-heading">Arminas Ignatavičius IFF/9-6 - 2022</p>
        <br />
        <a
          target="_blank"
          href="https://github.com/MisterChoccoMilk/housing-marketplace"
          className="footer-info-link"
          rel="noreferrer"
        >
          Github <i className="fab fa-github"></i>
        </a>
      </section>
    </div>
  );
}

export default Footer;

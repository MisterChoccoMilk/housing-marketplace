import React, { useEffect, useState } from "react";
import "../registeredPages.scss";
import { useLocation, useNavigate } from "react-router-dom";
import adsServices from "../../services/adsServices";

export default function AllAdsPage() {
    const location = useLocation();
    const [ads, setAds] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getAds();
    }, []);
    async function getAds() {
        var ads = await adsServices.getAds(location.state.categoryId);
        setAds(ads);
    }
    //const handleNavigate = () => {
    //    navigate("/user/useranimals");
    //};
    //const handleProcedures = async (event) => {
    //    event.preventDefault();
    //    navigate("procedures", {
    //        state: { visitId: event.target.value, animalId: location.state.animalId },
   //     });
    //};
    return (
        <>
            <div className="pages-container">
                <div className="pages-container-info">
                    <div className="pages-container-info-header">
                        <h2>Here you can find all the ads from specific category</h2>
                    </div>
                    {ads.length !== 0 ? (
                        <ul className="responsive-table">
                            <li className="table-header">
                                <div className="col col-1">Ad name</div>
                                <div className="col col-2">Ad description</div>
                            </li>
                            {ads.map((ad) => {
                                return (
                                    <li className="table-row" key={ad.id}>
                                        <div
                                            className="col col-1"
                                            data-label="Name"
                                            data-key={ad.name}
                                        >
                                            {ad.name}
                                        </div>
                                        <div
                                            className="col col-2"
                                            data-label="Description"
                                            data-key={ad.description}
                                        >
                                            {ad.description}
                                        </div>
                                    </li>
                                );
                            })}
                        </ul>
                    ) : (
                        <h1>Sorry, we could not find any ads </h1>
                    )}
                </div>
            </div>
        </>
    );
}
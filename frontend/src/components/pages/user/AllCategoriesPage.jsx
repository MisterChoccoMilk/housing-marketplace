import React, { useEffect, useState } from "react";
import "../registeredPages.scss";
import categoryService from "../../services/categoryServices";
import { useNavigate } from "react-router-dom";
import { confirmAlert } from "react-confirm-alert";

export default function AllCategoriesPage() {
    const [categories, setCategories] = useState([]);
    const [user, setUser] = useState();
    const [update, setUpdate] = useState();
    const navigate = useNavigate();
    useEffect(() => {
        getCategories();
        return () => {
            getCategories();
            setUpdate(false);
        };
    }, [update]);
    async function getCategories() {
        var categories = await categoryService.getCategories();
        const localUser = JSON.parse(localStorage.getItem("user"));
        setUser(localUser);
        setCategories(categories);
    }


    const handleAds = async (event) => {
        event.preventDefault();
        navigate("Ads", {
            state: { categoryId: event.target.value },
        });
    };

    return (
        <>
            <div className="pages-container">
                <div className="pages-container-info">
                    <div className="pages-container-info-header">
                        <h2>Here you can find all the categories</h2>
                    </div>
                    {categories.length !== 0 ? (
                        <ul className="responsive-table">
                            <li className="table-header">
                                <div className="col col-1">Category name</div>
                                <div className="col col-2">Category description</div>
                                <div className="col col-3">Ads</div>
                            </li>
                            {categories.map((category) => {
                                return (
                                    <li className="table-row" key={category.id}>
                                        <div
                                            className="col col-1"
                                            data-label="Name"
                                            data-key={category.name}
                                        >
                                            {category.name}
                                        </div>
                                        <div
                                            className="col col-2"
                                            data-label="Description"
                                            data-key={category.description}
                                        >
                                            {category.description}
                                        </div>
                                        <div className="col col-3" data-label="Ads">
                                            <button
                                                className="button-advertisments"
                                                value={category.id}
                                                onClick={handleAds}
                                            >
                                                Category ad's
                                            </button>
                                        </div>
                                    </li>
                                );
                            })}
                        </ul>
                    ) : (
                        <h1>Sorry, we could not find any categories </h1>
                    )}
                </div>
            </div>
        </>
    );
}

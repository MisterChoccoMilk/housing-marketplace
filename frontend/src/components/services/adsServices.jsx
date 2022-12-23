import axios from "axios";

const API_URL = "http://localhost:5259/api";

class adsServices {
    createAd(text, categoryId) {
        var data = JSON.stringify({
            description: text,
        });

        var config = {
            method: "post",
            url: API_URL + "/categories/" + categoryId + "/ads",
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
            data: data,
        };
        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                return error;
            });
    }
    getAds(categoryId) {
        var config = {
            method: "get",
            url: API_URL + "/categories/" + categoryId + "/ads",
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
        };
        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                return error;
            });
    }
    getAd(categoryId, adId) {
        var config = {
            method: "get",
            url: API_URL + "/categories/" + categoryId + "/ads/" + adId,
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
        };
        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                return error;
            });
    }
    updateVisit(text, categoryId, adId) {
        var data = JSON.stringify({
            description: text,
        });
        var config = {
            method: "put",
            url: API_URL + "/categories/" + categoryId + "/ads/" + adId,
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
            data: data,
        };
        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                return error;
            });
    }
    deleteAd(categoryId, adId) {
        var config = {
            method: "delete",
            url: API_URL + "/categories/" + categoryId + "/ads/" + adId,
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
        };
        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                return error;
            });
    }
}

export default new adsServices();

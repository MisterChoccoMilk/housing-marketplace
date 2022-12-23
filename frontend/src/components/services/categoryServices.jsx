import axios from "axios";

const API_URL = "http://localhost:5259/api";

class categoryServices {

    getCategories() {
        var config = {
            method: "get",
            url: API_URL + "/categories",
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
        };
        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    getCategory(Id) {
        var config = {
            method: "get",
            url: API_URL + "/categories/" + Id,
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
        };

        return axios(config)
            .then(function (response) {
                return response.data;
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    updateCategory(Id, Name, Description) {
        var user = JSON.parse(localStorage.getItem("user"));
        let userName = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        var data = JSON.stringify({
            name: Name,
            description: Description,
            owner: userName,
            UserId: user["sub"],
        });
        var config = {
            method: "put",
            url: API_URL + "/categories/" + Id,
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
            data: data,
        };
        return axios(config)
            .then(function (response) {
                return response;
            })
            .catch(function (error) {
                return error;
            });
    }

    createCategory(Name, Description) {
        var user = JSON.parse(localStorage.getItem("user"));
        let userName = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        var data = JSON.stringify({
            name: Name,
            description: Description,
            owner: userName,
            UserId: user["sub"],
        });
        var config = {
            method: "post",
            url: API_URL + "/categories/",
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json",
            },
            data: data,
        };
        return axios(config)
            .then(function (response) {
                return response;
            })
            .catch(function (error) {
                return error;
            });
    }
    deleteCategory(Id) {
        var config = {
            method: "delete",
            url: API_URL + "/categories/" + Id,
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
        };
        return axios(config)
            .then(function (response) {
                return response;
            })
            .catch(function (error) {
                return error;
            });
    }
}

export default new categoryServices();

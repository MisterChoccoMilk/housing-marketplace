import "./App.css";
import Navbar from "./components/Navbar";
import {
    BrowserRouter as Router,
    Routes,
    Route,
    Outlet,
} from "react-router-dom";
import ProtectedRoutes from "./components/services/protectedRoutes";
import {
    HomePage,
    UserPage,
    SignUpPage,
    LoginPage,
    AdsPage,
} from "./components/pages/index";
import Footer from "./components/Footer";

function App() {
    return (
        <>
            <Router>
                <Navbar />
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/sign-up" element={<SignUpPage />} />
                    <Route path="/login" element={<LoginPage />} />
                    <Route>
                        <Route
                            path="/user"
                            element={
                                <ProtectedRoutes requiredRole={"MarketplaceUser"} page={<UserPage/>} />
                            }
                        />
                        <Route
                            path="/user/Ads"
                            element={
                                <ProtectedRoutes requiredRole={"MarketplaceUser"} page={<AdsPage/>} />
                            }
                        />
                    </Route>
                </Routes>
                <Footer />
            </Router>
        </>
    );
}

export default App;
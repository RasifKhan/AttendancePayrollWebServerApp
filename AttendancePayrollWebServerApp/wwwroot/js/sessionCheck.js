function startSessionCheck(loginPath) {
    console.log("Starting session check for: " + loginPath);
    setInterval(async () => {
        console.log("Checking session...");
        try {
            const response = await fetch('/api/auth/check', {
                credentials: 'include'
            });
            console.log("Session check response: " + response.status);
            if (response.status === 401 || response.status === 403) {
                console.log("Session expired, redirecting to: " + loginPath);
                window.location.href = loginPath;
            }
        } catch (error) {
            console.log("Session check error, redirecting to: " + loginPath);
            window.location.href = loginPath;
        }
    }, 30000); // Check every 30 seconds
}



//function startSessionCheck(loginPath) {
//    setInterval(async () => {
//        try {
//            const response = await fetch('/api/auth/check', {
//                credentials: 'include' // Include cookies
//            });
//            if (response.status === 401 || response.status === 403) {
//                window.location.href = loginPath;
//            }
//        } catch (error) {
//            window.location.href = loginPath;
//        }
//    }, 30000); // Check every 30 seconds
//}
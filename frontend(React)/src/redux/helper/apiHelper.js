export const apiHelper = async ({
    url,
    method = "GET",
    body = null,
    headers = {},
}) => {

    const token = localStorage.getItem("accessToken"); // Saklanan token'ı alıyoruz
    console.log("Stored Token:", token); // Saklanan token'ı kontrol edin

    const defaultHeaders = {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`, // "Bearer " ve token arasında boşluk olduğundan emin olun
        ...headers,
    };

    try {
        const response = await fetch(url, {
            method,
            headers: defaultHeaders,
            body: body ? JSON.stringify(body) : null,
        });

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message || "API Hatası");
        }

        return await response.json();
    } catch (error) {
        console.error("API Hatası: ", error);
        throw error;
    }
};

export default apiHelper;
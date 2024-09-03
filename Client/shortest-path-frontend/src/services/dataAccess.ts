const baseUrl = "http://localhost:5244";

export const getPath = async(fromNodeName: string, toNodeName: string) => {
    const url = new URL(`${baseUrl}/shortestpath`);
    const searchParams = new URLSearchParams({
        fromNodeName: fromNodeName,
        toNodeName: toNodeName
    });
    url.search = searchParams.toString();

    try {
        const response = await fetch(url);

        if (response.ok) {
            const data = await response.json();
            data.success = true;
            return data;
        } else {
            return {
                success: false
            }
        }
    } catch (e) {
        return {
            success: false
        }
        console.error("Error in get data");
    }
};
window.onload = () => {

    const videoListLink = "https://api.rss2json.com/v1/api.json?rss_url=https://www.youtube.com/feeds/videos.xml?playlist_id=PL7sDGDcVXiNJBlYrI3yh3W-Fis6s2IORE";
    const area = document.querySelector('#listArea');

    fetch(videoListLink)
        .then(response => response.json())
        .then(data => {

            data.items.forEach(video => {
                const videoId = video.guid.split(":")[2];
                const embedLink = `<div class="col-md-3"><iframe style="width: 100%;" height="315" src="https://www.youtube.com/embed/${videoId}" title="${video.title}" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe></div>`;
                area.innerHTML += embedLink;
            });
        });

}
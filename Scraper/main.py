from requests import get
from time import sleep
from tqdm import tqdm

class URL:
    def __init__(self, url):
        url_parts = url.split(" ")
        self.table_name = url_parts[2]
        self.url = url_parts[3]

def load_urls():
    urls = []
    with open("wget.txt", "r") as file:
        urls = list(filter(lambda x: not x.startswith("#"), file.readlines()))

    return urls

def main():
    URLS = map(lambda x: URL(x), load_urls())
    headers = {
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:131.0) Gecko/20100101 Firefox/131.0",
        "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/png,image/svg+xml,*/*;q=0.8",
        "Accept-Language": "en-US,en;q=0.5",
        "Accept-Encoding": "gzip, deflate, br, zstd",
        "Connection": "keep-alive",
        "Cookie": "ISIS=2024.10.05_07.10.10_017193; _exoplanet_archive_overview_session=DI%2FimcjO0hRL4RN3wXd4XS4UMHp15yVlUuo8o8TJrnxukTOca3z%2BKf6PGJB7cGjeOecYsyyLxs46SBDvbwZ%2F1RkZiEZBFqi7AjxgVFNGHAzi%2FIqPBKojFGoc%2BU3zzLNg3MuAIxpdkzX0lCLCcAk%3D--nsFLs36mViT4UOYv--ea23V23ud1lpNIEeYqqoSA%3D%3D",
        "Upgrade-Insecure-Requests": "1",
        "Sec-Fetch-Dest": "document",
        "Sec-Fetch-Mode": "navigate",
        "Sec-Fetch-Site": "none",
        "Sec-Fetch-User": "?1",
        "If-Modified-Since": "Mon, 19 Aug 2024 16:20:22 GMT",
        "If-None-Match": "a581e1-6200baf8a38a8",
    }
    for url in tqdm(URLS):
        while True:
            try:
                data = get(url.url, headers=headers)
                if data.status_code == 200:
                    with open("data/" + url.table_name, "wb") as file:
                        file.write()
                        break
                print(f"Received : {data.status_code}, rate limited ?")
            except:
                print(f"Timeout !, retrying soon")
            sleep(5)
    print("Every dataset has been downloaded!")

if __name__ == "__main__":
    main()
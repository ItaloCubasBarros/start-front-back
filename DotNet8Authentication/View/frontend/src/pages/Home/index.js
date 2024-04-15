import React, { useState, useEffect } from 'react';
import api from '../../utils/api';
import styles from './Home.module.css';
import Pagination from '../../components/Pagination';
import { Link } from 'react-router-dom';

function Home() {
    const [news, setNews] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 10;

    useEffect(() => {
        api.get('https://localhost:7251/api/News').then((response) => {
            setNews(response.data.news || []); // Certifique-se de definir um array vazio caso response.data.news seja undefined
        });
    }, []);

    const indexOfLastItem = currentPage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentItems = news.slice(indexOfFirstItem, indexOfLastItem);

    const paginate = (pageNumber) => setCurrentPage(pageNumber);

    return (
        <section className={styles.container}>
            <div className={styles.newsList}>
                {currentItems.length > 0 ? (
                    currentItems.map((newsItem) => (
                        <figure className={styles.card} key={newsItem.id}>
  
                            <div className={styles.cardImgOverlay}>
                                <h3 className={styles.cardTitle}>{newsItem.title}</h3>
                                <p className={styles.cardText}><span>Subtitulo:</span> {newsItem.caption}</p>
                            </div>
                            <figcaption className={styles.cardBody}>
                                <div dangerouslySetInnerHTML={{ __html: newsItem.body.slice(0, 155) }} />
                                {newsItem.article && newsItem.article.length > 155 &&
                                    <Link to={`/news/details/${newsItem.id}`}>... Leia mais</Link>
                                }
                            </figcaption>
                        </figure>
                    ))
                ) : (
                    <p>Não há noticias disponíveis para visualizar no momento!</p>
                )}
            </div>

            <Pagination
                itemsPerPage={itemsPerPage}
                totalItems={news.length}
                paginate={paginate}
                currentPage={currentPage}
                className={styles.pagination}
            />
        </section>
    );
}

export default Home;

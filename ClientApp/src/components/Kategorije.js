import axios from 'axios';
import React, { Component} from 'react'

import "./Kategorije.css"

export class Kategorije extends Component {

    constructor(props)
    {
        super(props);

        this.state = {

            kategorije: null,
            podkategorije: null
        }
    }

    componentDidMount()
    {
        axios.get('https://localhost:5001/api/kategorije')
        .then(response => {
            this.setState({kategorije : response.data});
        }).catch(function(error)
            {
                console.log(error);
            }
        )

        axios.get('https://localhost:5001/api/potkategorije')
        .then(response => {
            this.setState({potkategorije : response.data});
        }).catch(function(error)
            {
                console.log(error);
            }
        )

    }

    render() {
        console.log(this.state.potkategorije)
        console.log(this.state.kategorije)
        return (
            <>
                {this.state.kategorije && this.state.kategorije.map(kategorija=>{
                return <div class="dropdown kategorija-dropdown">
                            <a class="btn btn-secondary dropdown-toggle" href="/" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                {kategorija.naziv}
                            </a>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                                {
                                    this.state.potkategorije && this.state.potkategorije.map(potkat=>
                                        {
                                            if(potkat.kategorijaNaziv === kategorija.naziv)
                                                return <a class="dropdown-item" href="/">{potkat.naziv}</a>
                                        })
                                }
                            </div>
                        </div>
                })}
            </>
        );
    }
}

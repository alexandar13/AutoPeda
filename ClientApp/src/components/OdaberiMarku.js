import React, {Component} from "react";
import {Button} from "reactstrap";
import axios from 'axios';
import './OdaberiMarku.css';


export class OdaberiMarku extends Component
{
    constructor(props)
    {
        super(props);

        this.state =
        {
            marke: [],
            modeli: [],
            godista: [],
            odabranaMarka:null ,
            odabranModel:null,
            odabranoGodiste:null
        };
    }

    componentDidMount()
    {
        axios.get('https://localhost:5001/api/marke')
        .then(response =>{
            this.setState({ marke : response.data });
        }).catch(function(error)
            {
                console.log(error);
            }
        )
    }

    ucitajModele(event)
    {
        this.setState({odabranaMarka : event.target.value});

        if(event.target.value === "Odaberi marku")
        {
            this.setState({odabranaMarka : null});
            this.setState({odabranModel : null});
            this.setState({odabranoGodiste : null});
        }

        this.setState({modeli : []})
        this.setState({godista : []})

        axios.get('https://localhost:5001/api/modeli/ZaMarku/' + event.target.value)
        .then(response =>{
            response.data.forEach(element => {
                if(!this.state.modeli.includes(element.naziv))
                {
                    var joined=this.state.modeli.concat(element.naziv);
                    this.setState({modeli : joined});
                };
            });
        }).catch(function(error)
            {
                console.log(error);
            }
        )
    }

    ucitajGodista(event)
    {
        this.setState({godista : []});
        this.setState({odabranModel : event.target.value});

        if(event.target.value === "Odaberi model")
        {
            this.setState({odabranModel : null});
            this.setState({odabranoGodiste : null});
        }
        else
        {
            axios.get("https://localhost:5001/api/modeli/PoNazivu/"+event.target.value+"/"+this.state.odabranaMarka)
            .then(response =>{
                response.data.forEach(data =>{
                    var joined = this.state.godista.concat([{Od : data.godisteOd, Do : data.godisteDo}]);
                    this.setState({godista : joined});
                })
            }).catch(function(error) {
                console.log(error);
            })
        }   
    }

    odaberiGodiste(event)
    {
        this.setState({odabranoGodiste : event.target.value});

        if(event.target.value === "Odaberi model")
        {
            this.setState({odabranoGodiste : null});
        }
    }

    Prosledi()
    {
        this.props.odabirAuta([{marka : this.state.odabranaMarka, model : this.state.odabranModel, godiste : this.state.odabranoGodiste}])
    }

    render()
    {
        this.state.godista.sort((a, b) => a.Od - b.Od)
        this.state.marke.sort((a, b) => a.Naziv > b.Naziv ? -1 : 1)
        return(
            <>
                <div class="odaberi">
                    <div class="odaberi-item">
                        <select class="select" id="slect-marka" onChange={this.ucitajModele.bind(this)} aria-label="Default select example">
                            <option defaultValue>Odaberi marku</option>
                            {this.state.marke.map(item=>{
                                    return <option key={item.naziv} value={item.naziv}>{item.naziv}</option>
                            })}
                        </select>
                    </div>
                    <div class="odaberi-item">
                        <select class="select" onChange={this.ucitajGodista.bind(this)} aria-label="Default select example">
                            <option defaultValue>Odaberi model</option>
                            {this.state.modeli.map(item=>{
                                    return <option key={item} value={item}>{item}</option>
                            })}
                        </select>
                    </div>
                    <div class="odaberi-item">
                        <select class="select" onChange={this.odaberiGodiste.bind(this)} aria-label="Default select example">
                            <option defaultValue>Odaberi godiste</option>
                            {this.state.godista.map(item=>{
                                    return <option key={item.Od, item.Do} value={item.Od}>{item.Od+"-"+item.Do}</option>
                            })}
                        </select>
                    </div>
                    <div class="odaberi-item">
                        <Button className="dugme" color="primary" onClick={this.Prosledi.bind(this)}>Pretraga</Button>
                    </div>
                </div>
            </>
        );
    }
}
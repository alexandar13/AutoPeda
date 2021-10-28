import React, { Component } from 'react';
import {OdaberiMarku} from "./OdaberiMarku"
import {Kategorije} from "./Kategorije"
//import ReactDOM from 'react-dom';
import "./Home.css"

export class Home extends Component {
  static displayName = Home.name;

  constructor(props)
  {
    super(props)

    this.state={
      k : "null"
    }

  }

  promeni()
  {
    this.setState({
      k : this.props.odabranAuto.marka
    })
  }

  componentDidUpdate(prevProps)
  {
    if(prevProps !== this.props)
    {  
      this.azuriraj()
    }
  }

  azuriraj()
  {
    this.setState({k:this.props.odabranAuto})
  }

  render () {

    return (
      <>
        <div>
          {this.state.k}
        </div>
      </>
    );  
  }
}

import React, { Component } from 'react';
//import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import {OdaberiMarku} from './OdaberiMarku'
import {Kategorije} from './Kategorije'
import {Home} from './Home'

export class Layout extends Component {
  static displayName = Layout.name;

  constructor(props)
  {
    super(props)

    this.state = 
    {
      auto : [{marka : "null", model : "null", godiste : "null"}]
    }

    this.odabirAuta=this.odabirAuta.bind(this)
  }


  odabirAuta(auto2)
  {
   this.setState({auto : auto2})
  }

  render () {
    return (
      <div>
        <NavMenu></NavMenu>
        <div class="kontejner-column">
          <div class="navbar-cover"></div>
          <div id="sidebar" class="sidebar">
            <OdaberiMarku odabirAuta={this.odabirAuta}></OdaberiMarku>
          </div>
          <div class="container-fluid">
            <div class="kategorije">
              <Kategorije></Kategorije>
            </div>
            <Home odabranAuto={this.state.auto[0].marka }></Home>
          </div>
        </div>
      </div>
    );
  }
}

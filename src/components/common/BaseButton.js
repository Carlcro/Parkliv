import React from 'react';
import { Button } from 'react-bootstrap';

class BaseButton extends React.Component {
	constructor(...args) {
		super(...args);

		this.handleClick = this.handleClick.bind(this);

		this.state = {
			isLoading: false,
      btnStyle: "primary"
		};
	}

	handleClick() {
		this.setState({ isLoading: true,
                    btnStyle: "danger"});

		// This probably where you would have an `ajax` call
		setTimeout(() => {
			// Completed of async action, set loading state back
			this.setState({ isLoading: false,
                      btnStyle: "success"});
		}, 2000);
	}

	render() {
		let isLoading = this.state.isLoading;
		return (
			<Button
				bsStyle= {this.state.btnStyle}
        bsSize="large"
				disabled={isLoading}
				onClick={!isLoading ? this.handleClick : null}
			>
				{isLoading ? 'Loading...': this.props.text }
			</Button>
		);
	}
}

export default BaseButton;

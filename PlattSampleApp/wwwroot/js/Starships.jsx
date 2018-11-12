
class Loading extends React.Component {
    render() {
        return (
            <span>Loading...</span>
        );
    }
}

class StarshipRow extends React.Component {
    render() {
        const starship = this.props.starship;

        return (
            <tr>
                <td>{starship.name}</td>
                <td>{starship.class}</td>
                <td>{starship.manufacturer}</td>
                <td>{starship.cost}</td>
            </tr>
        );
    }
}

class StarshipTable extends React.Component {
    render() {
        const rows = [];

        this.props.starships.forEach((starship) => {
            rows.push(
                <StarshipRow
                    starship={starship}
                    key={starship.name} />
            );
        });

        return (
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Class</th>
                        <th>Manufacturer</th>
                        <th>Cost</th>
                    </tr>
                </thead>
                <tbody>
                    {rows}
                </tbody>
            </table>
        );
    }
}

class StarshipSearch extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            isLoading: true,
            starships: [],
            error: null
        };
    }

    fetchStarships() {
        fetch("/Home/StarshipsJson")
            .then(response => response.json())
            .then(data =>
                this.setState({
                    starships: data,
                    isLoading: false
                })
            )
            .catch(error => this.setState({
                error,
                isLoading: false
            }));
    }

    componentDidMount() {
        this.fetchStarships();
    }

    render() {
        return (
            <div id="starship-search">
                {this.state.error ? <div className="alert alert-danger">{this.state.error.message}</div> : null}
                {!this.state.isLoading ? (
                    <StarshipTable starships={this.state.starships} />
                ) : (
                    <Loading />
                )}
            </div>
        );
    }
}

ReactDOM.render(<StarshipSearch />, document.getElementById("starships"));

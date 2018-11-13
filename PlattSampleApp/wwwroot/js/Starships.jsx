
class Loading extends React.Component {
    render() {
        return (
            <span>Loading...</span>
        );
    }
}

class SearchPanel extends React.Component {
    constructor(props) {
        super(props);

        this.handleSearchTextChange = this.handleSearchTextChange.bind(this);
        this.handleCostMinChange = this.handleCostMinChange.bind(this);
        this.handleCostMaxChange = this.handleCostMaxChange.bind(this);
    }

    handleSearchTextChange(e) {
        this.props.onSearchTextChange(e.target.value);
    }

    handleCostMinChange(e) {
        this.props.onCostMinChange(e.target.value);
    }

    handleCostMaxChange(e) {
        this.props.onCostMaxChange(e.target.value);
    }

    render() {
        return (
            <div className="well">
                <form className="row">
                    <div className="form-group col-xs-12 col-md-6 col-lg-8">
                        <input
                            type="text"
                            placeholder="Search..."
                            className="form-control"
                            value={this.props.searchText}
                            onChange={this.handleSearchTextChange}
                        />
                    </div>
                    <div className="form-group col-xs-12 col-md-3 col-lg-2">
                        <input
                            type="number"
                            placeholder="Min"
                            className="form-control"
                            value={this.props.costMin || ""}
                            onChange={this.handleCostMinChange}
                        />
                    </div>
                    <div className="form-group col-xs-12 col-md-3 col-lg-2">
                        <input
                            type="number"
                            placeholder="Max"
                            className="form-control"
                            value={this.props.costMax || ""}
                            onChange={this.handleCostMaxChange}
                        />
                    </div>
                </form>
            </div>
        );
    }
}

class StarshipRow extends React.Component {
    render() {
        const starship = this.props.starship;

        return (
            <React.Fragment>
                <tr>
                    <td>{starship.name}</td>
                    <td>{starship.class}</td>
                    <td>{starship.manufacturer}</td>
                    <td>{starship.cost}</td>
                </tr>
            </React.Fragment>
        );
    }
}

class StarshipTable extends React.Component {
    render() {
        const searchText = this.props.searchText;
        const costMin = this.props.costMin;
        const costMax = this.props.costMax;

        const rows = [];

        this.props.starships.forEach((starship) => {
            // TODO: Loop through the starship object's properties and perform the match on each (instead of explicitly checking)
            var searchTextMismatch = (
                starship.name.toLowerCase().indexOf(searchText.toLowerCase()) === -1
                && starship.class.toLowerCase().indexOf(searchText.toLowerCase()) === -1
                && starship.manufacturer.toLowerCase().indexOf(searchText.toLowerCase()) === -1
            );

            var costMismatch = (
                (costMin && !starship.cost)
                || (costMin && starship.cost < costMin)
                || (costMax && starship.cost > costMax)
            );

            if (searchTextMismatch || costMismatch) {
                return;
            }

            rows.push(
                <StarshipRow
                    starship={starship}
                    key={starship.name}
                />
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
            error: null,
            searchText: "",
            costMin: undefined,
            costMax: undefined
        };

        this.handleSearchTextChange = this.handleSearchTextChange.bind(this);
        this.handleCostMinChange = this.handleCostMinChange.bind(this);
        this.handleCostMaxChange = this.handleCostMaxChange.bind(this);
    }

    handleSearchTextChange(searchText) {
        this.setState({
            searchText: searchText
        });
    }

    handleCostMinChange(costMin) {
        this.setState({
            costMin: costMin
        });
    }

    handleCostMaxChange(costMax) {
        this.setState({
            costMax: costMax
        });
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
                <SearchPanel
                    searchText={this.state.searchText}
                    onSearchTextChange={this.handleSearchTextChange}
                    costMin={this.state.costMin}
                    onCostMinChange={this.handleCostMinChange}
                    costMax={this.state.costMax}
                    onCostMaxChange={this.handleCostMaxChange}
                />
                {this.state.error ? <div className="alert alert-danger">{this.state.error.message}</div> : null}
                {!this.state.isLoading ? (
                    <StarshipTable
                        starships={this.state.starships}
                        searchText={this.state.searchText}
                        costMin={this.state.costMin}
                        costMax={this.state.costMax}
                    />
                ) : (
                        <Loading />
                    )}
            </div>
        );
    }
}

ReactDOM.render(<StarshipSearch />, document.getElementById("starships"));

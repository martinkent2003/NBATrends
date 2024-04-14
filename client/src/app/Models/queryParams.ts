
export class QueryParams {
    selectTeam: Boolean
    selectPlayer: Boolean
    teamsSelected: String[]
    playersSelected: String[]

    constructor() {
        this.selectTeam = true
        this.selectPlayer = false
        this.teamsSelected = []
        this.playersSelected = []
    }

    setSelectTeam() {
        this.selectTeam = true;
        this.selectPlayer = false;
    }
    
    setSelectPlayer() {
        this.selectTeam = false;
        this.selectPlayer = true;
    }
    
    addPlayerToList(name: String) {
        const index = this.playersSelected.indexOf(name, 0);
        if (index == -1) {
          this.playersSelected.push(name)
        }
    }
    
    addTeamToList(name: String) {
        const index = this.teamsSelected.indexOf(name, 0);
        if (index == -1) {
          this.teamsSelected.push(name)
        }
    }
    
    removePlayerFromList(name: String) {
        const index = this.playersSelected.indexOf(name, 0);
        if (index > -1) {
          this.playersSelected.splice(index, 1);
        }
    }
    
    removeTeamFromList(name: String) {
        const index = this.teamsSelected.indexOf(name, 0);
        if (index > -1) {
          this.teamsSelected.splice(index, 1);
        }
    }
}
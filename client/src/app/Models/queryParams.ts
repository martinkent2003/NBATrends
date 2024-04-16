
export class QueryParams {
  queryOption: Number

  attributeSelected: number
  fromYear: Number
  toYear: Number

  selectTeam: Boolean
  teamsSelected: String[]
  showHomeAway: Boolean

  selectPlayer: Boolean
  playersSelected: String[]

  attributeOptionDisplay: String
  attributeOptions: String[] = [
    'FieldGoalsMade',
    'FieldGoalsAttempted',
    'FieldGoalPercentage',
    'FGThreesMade',
    'FGThreesAttempted',
    'FGThreePercentage',
    'FreeThrowsMade',
    'FreeThrowsAttempted',
    'FreeThrowPercentage',
    'OffensiveRebounds',
    'DefensiveRebounds',
    'Rebounds',
    'Assists',
    'Steals',
    'Blocks',
    'Turnovers',
    'PersonalFouls',
    'Points',
    'PlusMinus'
  ]

  constructor() {
    this.queryOption = 0
    this.attributeSelected = 17
    this.attributeOptionDisplay = 'Points'
    this.fromYear = 1985
    this.toYear = 2023
    this.selectTeam = true
    this.teamsSelected = []
    this.showHomeAway = false
    this.selectPlayer = false
    this.playersSelected = []
  }

  changeQueryOption(ind: Number) {
    if (ind == this.queryOption) {
      this.queryOption = -1;
    }
    else {
      this.queryOption = ind;
    }
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

  chooseAttribute(ind: number, name: String) {
    this.attributeSelected = ind
    this.attributeOptionDisplay = name
  }
}
<template>
    <div class="content">
        <div v-if="!itemsLoaded" class="col">
            <div class="alert alert-success">
                Загрузка...
            </div>
        </div>
        <template v-else>
            <b-alert variant="danger" :show="error !== null" dismissible @dismissed="error = null">
                {{ error }}
            </b-alert>

            <b-nav tabs>
                <b-nav-item :active="!shoppingArea" v-on:click="onResetShoppingArea">Все</b-nav-item>
                <b-nav-item :active="shoppingArea" v-on:click="onSetShoppingArea">Территория</b-nav-item>
            </b-nav>

            <form @submit.prevent="filterData">
                <b-input-group-append>
                    <b-form-input type="text" placeholder="Отбор" class="m-1 p-1" v-model="filter" size="sm"/>
                    <b-btn type="submit" text="Button" variant="outline-secondary" size="sm"
                           class="m-1 p-1"
                            v-on:click="fetchData">
                        Найти
                    </b-btn>
                </b-input-group-append>
            </form>

            <div v-for="customer in customers"
                 :key="customer.customerId"
                 class="card m-1 p-1 bg-light">
                    {{customer.descr}} ИНН {{customer.inn}} <small>{{customer.addressPost}}</small>

                    <div class="card-text bg-white p-1">
                        <template v-if="!shoppingArea">
                            <button class="btn btn-primary btn-sm float-left"
                                    v-on:click="onAddToShoppingArea(customer)"
                            >
                                Добавить
                            </button>
                        </template>
                        <template v-else>
                            <button class="btn btn-danger btn-sm float-left"
                                    v-on:click="onDeleteToShoppingArea(customer)"
                            >
                                Удалить
                            </button>
                        </template>

                        <button class="btn btn-success btn-sm float-right"
                                v-on:click="onAddToCart(customer)"
                        >
                            Выбрать
                        </button>
                    </div>
            </div>

            <template v-if="totalPages>1">
                <b-pagination align="center" size="md" v-model="currentPage" :total-rows="totalCount" :per-page="pageSize" :limit=10>
                </b-pagination>
            </template>
        </template>
    </div>
</template>

<script>  
  import {mapGetters} from 'vuex';
  import {mapMutations} from 'vuex';

  export default {
    name: 'CustomerList',
    created(){
      this.fetchData();
    },
    data(){
      return {
        filter: '',
        totalCount: 0,
        totalPages: 0,
        currentPage: 1,
        pageSize: 1,
        itemsLoaded: false,
        shoppingArea: true,
        error: null
      }
    },
    computed: {    	
		...mapGetters({
          customers: 'customers/items'
		})
	},
    watch: {
      'currentPage': 'fetchData'
    },
    methods:{
      ...mapMutations({ addCustomer: "cart/addCustomer" }),
      fetchData () {
        this.itemsLoaded = false;
        this.$store
          .dispatch('customers/loadItems',
            {filter: this.filter,
            page:   this.currentPage,
            shoppingArea: this.shoppingArea})
          .then((response ) => {
            this.totalCount = response.data.totalCount;
            this.totalPages = response.data.totalPages;
            this.pageSize = response.data.pageSize;
            this.itemsLoaded = true;
            this.error = null;
          })
          .catch(error => {
            this.itemsLoaded = true;
            if (error === undefined) {
              this.error = 'Нет связи c API сервером';
            } else {
              this.error = error.data.error;
            }
          });
      },
      filterData(){
        this.currentPage = 1;
        this.fetchData();
      },
      onAddToCart(customer){
        this.addCustomer(customer);
        this.$router.push("/cart");
      },
      onAddToShoppingArea(customer){
         this.$store
           .dispatch('customers/addToShoppingAria',customer)
           // eslint-disable-next-line
           .then((response ) => {
             // eslint-disable-next-line
             //console.log(response.data)
           })
           // eslint-disable-next-line
          .catch(error => {
            // eslint-disable-next-line
              //console.log(error);
            });
      },
      onDeleteToShoppingArea(customer){
        this.$store
          .dispatch('customers/deleteToShoppingAria',customer)
          // eslint-disable-next-line
          .then((response ) => {
            // eslint-disable-next-line
            //console.log(response.data)
          })
          // eslint-disable-next-line
          .catch(error => {
            // eslint-disable-next-line
            //console.log(error);
          });
      },
      onResetShoppingArea(){
        this.shoppingArea = false;
        this.filterData();
      },
      onSetShoppingArea(){
        this.shoppingArea = true;
        this.filterData();
      }
    }
  }
</script>
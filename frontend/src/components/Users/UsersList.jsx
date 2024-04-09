import { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TablePagination,
  TableRow,
  TextField,
  Paper,
  Button,
  Box,
  IconButton,
  Dialog,
  DialogTitle,
  DialogContent,
} from "@mui/material";
import { Edit, Delete, Add, Close, Visibility } from "@mui/icons-material";
import { Link } from "react-router-dom";
import UserForm from "./UserForm";
import { deleteUser, fetchUsers } from "../../redux/actions/userActions";

const UsersList = () => {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const [searchText, setSearchText] = useState("");
  const [open, setOpen] = useState(false);
  const [selectedUserId, setSelectedUserId] = useState(null);
  const dispatch = useDispatch();
  const users = useSelector((state) => state.user.users);

  useEffect(() => {
    if (users && users.length === 0) {
      dispatch(fetchUsers());
    }
  }, [dispatch, users]);

  const handleEdit = (userId) => {
    setSelectedUserId(userId);
    setOpen(true);
  };

  const handleDelete = async (userId) => {
    try {
      dispatch(deleteUser(userId));
    } catch (error) {
      console.error("Error deleting user:", error);
    }
  };

  const handleAdd = () => {
    setSelectedUserId(null);
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const filteredUsers =
    users &&
    users.length > 0 &&
    users.filter(
      (user) =>
        user &&
        user.firstName &&
        user.firstName.toLowerCase().includes(searchText.toLowerCase())
    );

  return (
    <>
      <Box sx={{ padding: 3, paddingLeft: 3 }}>
        <div>
          <Box
            display="flex"
            justifyContent="space-between"
            alignItems="center"
            mb={2}
          >
            <TextField
              label="Search"
              variant="outlined"
              value={searchText}
              onChange={(e) => setSearchText(e.target.value)}
              sx={{
                height: "40px",
                fontSize: "14px",
                marginTop: "20px",
                marginBottom: "20px",
              }}
            />
            <Button
              variant="contained"
              color="primary"
              startIcon={<Add />}
              onClick={handleAdd}
              sx={{ height: "40px", fontSize: "12px", marginTop: "20px" }}
            >
              Add User
            </Button>
          </Box>
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>ID</TableCell>
                  <TableCell>UserName</TableCell>
                  <TableCell>Name</TableCell>
                  <TableCell>Email</TableCell>
                  <TableCell>Gender</TableCell>
                  <TableCell>Country</TableCell>
                  <TableCell>Role</TableCell>
                  <TableCell>Actions</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {filteredUsers &&
                  filteredUsers
                    .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                    .map((user) => (
                      <TableRow key={user.id}>
                        <TableCell>{user.id}</TableCell>
                        <TableCell>{user.userName}</TableCell>
                        <TableCell>
                          {user.lastName}, {user.firstName}
                        </TableCell>
                        <TableCell>{user.email}</TableCell>
                        <TableCell>{user.gender}</TableCell>
                        <TableCell>{user.country}</TableCell>
                        <TableCell>{user.role}</TableCell>
                        <TableCell>
                          <IconButton
                            aria-label="edit"
                            onClick={() => handleEdit(user.id)}
                          >
                            <Edit />
                          </IconButton>
                          <IconButton
                            aria-label="delete"
                            onClick={() => handleDelete(user.id)}
                          >
                            <Delete />
                          </IconButton>

                          <IconButton
                            aria-label="view"
                            component={Link}
                            to={`/users/${user.id}`}
                          >
                            <Visibility />
                          </IconButton>
                        </TableCell>
                      </TableRow>
                    ))}
              </TableBody>
            </Table>
          </TableContainer>
          <TablePagination
            rowsPerPageOptions={[5, 10, 25, 50, 100]}
            component="div"
            count={filteredUsers ? filteredUsers.length : 0}
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={handleChangePage}
            onRowsPerPageChange={handleChangeRowsPerPage}
          />
          <Dialog open={open} onClose={handleClose}>
            <DialogTitle>
              {selectedUserId ? "Edit User" : "Add User"}
              <IconButton
                aria-label="close"
                onClick={handleClose}
                sx={{
                  position: "absolute",
                  right: 8,
                  top: 8,
                }}
              >
                <Close />
              </IconButton>
            </DialogTitle>

            <DialogContent>
              <UserForm userId={selectedUserId} handleClose={handleClose} />
            </DialogContent>
          </Dialog>
        </div>
      </Box>
    </>
  );
};

export default UsersList;
